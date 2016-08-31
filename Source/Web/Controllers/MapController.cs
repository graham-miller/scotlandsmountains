using Microsoft.AspNetCore.Mvc;
using ScotlandsMountains.Domain;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class MapController : Controller
    {
        private readonly DomainRoot _domainRoot;

        public MapController(DomainRoot domainRoot)
        {
            _domainRoot = domainRoot;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            return new ObjectResult(_domainRoot.Maps);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var map = _domainRoot.Maps.GetById(id);

            if (map == null)
                return NotFound();

            return new ObjectResult(map);
        }
    }
}
