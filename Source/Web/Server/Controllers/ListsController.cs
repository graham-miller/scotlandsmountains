using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Web.Server.Models;

namespace ScotlandsMountains.Web.Server.Controllers
{
    [Route("api/[controller]")]
    public class ListsController : EntitiesController<List>
    {
        public ListsController(IDomainRoot domainRoot) : base(domainRoot, x => x.Lists) { }

        [HttpGet("{id}")]
        public override IActionResult Get(string id)
        {
            var list = DomainRoot.Lists.Single(x=> x.Id == id);

            var mountains = DomainRoot.Mountains
                .Where(x => x.ListIds.Contains(list.Id))
                .OrderByDescending(x => x.Height)
                .Select(x => new MountainSummaryModel(x));

            return new ObjectResult(mountains);
        }
    }
}