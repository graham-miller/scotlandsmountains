using System;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Web.Server.Controllers
{
    [Route("api/[controller]")]
    public class MountainsController : DomainRootController
    {
        public MountainsController(IDomainRoot domainRoot) : base(domainRoot) { }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var mountain = DomainRoot.Mountains.GetById(id);

            if (mountain == null)
                return NotFound();

            return new ObjectResult(mountain);
        }

        [HttpGet("search/{term?}/{page:int?}/{pageSize:int?}")]
        public IActionResult Search(string term = "", int page = 1, int pageSize = 50)
        {
            page = page < 1 ? 1 : page;
            pageSize = pageSize < 1 ? 1 : pageSize;
            pageSize = pageSize > 100 ? 100 : pageSize;

            Func<Mountain,bool> isMatch = x => CultureInfo.CurrentCulture.CompareInfo.IndexOf(x.Name, term, CompareOptions.IgnoreCase) >= 0;

            var count = DomainRoot.Mountains.Where(isMatch).Count();
            var pages = (count / pageSize) + 1;

            page = page > pages ? pages : page;

            var results = DomainRoot.Mountains
                .Where(isMatch)
                .OrderByDescending(x => x.Height)
                .Skip((page-1) * pageSize)
                .Take(pageSize);

            return new ObjectResult(new { page, pageSize, pages, count, results });
        }

        [HttpGet("{id}/Maps")]
        public IActionResult GetMaps(string id)
        {
            var mountain = DomainRoot.Mountains.GetById(id);

            if (mountain == null)
                return NotFound();

            return new ObjectResult(mountain.MapIds.Select(x => DomainRoot.Maps.GetById(x)));
        }

        [HttpGet("{id}/Classifications")]
        public IActionResult GetClassifications(string id)
        {
            var mountain = DomainRoot.Mountains.GetById(id);

            if (mountain == null)
                return NotFound();

            return new ObjectResult(mountain.ClassificationIds.Select(x => DomainRoot.Classifications.GetById(x)));
        }

        [HttpGet("{id}/Section")]
        public IActionResult GetSection(string id)
        {
            var mountain = DomainRoot.Mountains.GetById(id);

            if (mountain == null)
                return NotFound();

            return new ObjectResult(DomainRoot.Sections.GetById(mountain.SectionId));
        }

        [HttpGet("{id}/Country")]
        public IActionResult GetCountry(string id)
        {
            var mountain = DomainRoot.Mountains.GetById(id);

            if (mountain == null)
                return NotFound();

            return new ObjectResult(DomainRoot.Countries.GetById(mountain.CountryId));
        }
    }
}
