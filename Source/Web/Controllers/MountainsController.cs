using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ScotlandsMountains.Domain;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class MountainsController : Controller
    {
        private DomainRoot _domainRoot;

        public MountainsController(DomainRoot domainRoot)
        {
            _domainRoot = domainRoot;
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var mountain = _domainRoot.Mountains.SingleOrDefault(x => x.Id == id);

            if (mountain == null)
                return NotFound();

            return new ObjectResult(mountain);
        }
    }
}
