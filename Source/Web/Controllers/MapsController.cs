using Microsoft.AspNetCore.Mvc;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Web.Controllers
{
    [Route("api/[controller]")]
    public class MapsController : DomainRootController
    {
        public MapsController(IDomainRoot domainRoot) : base(domainRoot) { }

        [HttpGet()]
        public IActionResult Get()
        {
            return new ObjectResult(DomainRoot.Maps);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var map = DomainRoot.Maps.GetById(id);

            if (map == null)
                return NotFound();

            return new ObjectResult(map);
        }
    }
}
