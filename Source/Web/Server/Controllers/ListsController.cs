using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Web.Server.Models;
using Humanizer;

namespace ScotlandsMountains.Web.Server.Controllers
{
    [Route("api/[controller]")]
    public class ListsController : EntitiesController<List>
    {
        public ListsController(IDomainRoot domainRoot) : base(domainRoot, x => x.Lists) { }

        [HttpGet("{Name}")]
        public override IActionResult Get(string name)
        {
            Func<List, bool> isMatch = x => x.Name.Equals(name.Singularize(), StringComparison.InvariantCultureIgnoreCase);
            var list = DomainRoot.Lists.Single(isMatch);

            if (list == null)
                return base.Get(name);

            var mountains = DomainRoot.Mountains
                .Where(x => x.ListIds.Contains(list.Id))
                .OrderByDescending(x => x.Height)
                .Select(x => new MountainSummaryModel(x));

            return new ObjectResult(mountains);
        }
    }
}