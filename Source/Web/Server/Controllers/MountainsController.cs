using Microsoft.AspNetCore.Mvc;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Web.Server.Models;

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

            return new ObjectResult(new MountainModel(mountain, DomainRoot));
        }
    }
}