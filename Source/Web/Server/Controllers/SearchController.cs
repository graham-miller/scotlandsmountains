using System;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Web.Server.Models;

namespace ScotlandsMountains.Web.Server.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : DomainRootController
    {
        public SearchController(IDomainRoot domainRoot) : base(domainRoot) { }

        [HttpGet("{term?}/{page:int?}/{pageSize:int?}")]
        public IActionResult Search(string term = "", int page = 1, int pageSize = 50)
        {
            page = page < 1 ? 1 : page;
            pageSize = pageSize < 1 ? 1 : pageSize;
            pageSize = pageSize > 100 ? 100 : pageSize;

            Func<Mountain, bool> isMatch = x => CultureInfo.InvariantCulture.CompareInfo.IndexOf(x.Name, term, CompareOptions.IgnoreCase) >= 0;

            var count = DomainRoot.Mountains.Where(isMatch).Count();
            var pages = (count / pageSize) + 1;

            page = page > pages ? pages : page;

            var results = DomainRoot.Mountains
                .Where(isMatch)
                .OrderByDescending(x => x.Height)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new MountainSummaryModel(x));

            return new ObjectResult(new { term, page, pageSize, pages, count, results });
        }
    }
}