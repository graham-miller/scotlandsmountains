using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ScotlandsMountains.Domain;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class MountainsController : Controller
    {
        private readonly DomainRoot _domainRoot;

        public MountainsController(DomainRoot domainRoot)
        {
            _domainRoot = domainRoot;
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var mountain = _domainRoot.Mountains.GetById(id);

            if (mountain == null)
                return NotFound();

            return new ObjectResult(mountain);
        }

        [HttpGet("{id}/Maps")]
        public IActionResult GetMaps(string id)
        {
            var mountain = _domainRoot.Mountains.GetById(id);

            if (mountain == null)
                return NotFound();

            return new ObjectResult(mountain.MapIds.Select(x => _domainRoot.Maps.GetById(x)));
        }

        [HttpGet("{id}/Classifications")]
        public IActionResult GetClassifications(string id)
        {
            var mountain = _domainRoot.Mountains.GetById(id);

            if (mountain == null)
                return NotFound();

            return new ObjectResult(mountain.ClassificationIds.Select(x => _domainRoot.Classifications.GetById(x)));
        }
    }
}
