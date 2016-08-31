using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ScotlandsMountains.Domain;
using System.Globalization;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class MountainController : Controller
    {
        private readonly DomainRoot _domainRoot;

        public MountainController(DomainRoot domainRoot)
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

        [HttpGet("search/{term}")]
        public IActionResult Search(string term)
        {
            return new ObjectResult(_domainRoot.Mountains.Where(x => 
                CultureInfo.CurrentCulture.CompareInfo.IndexOf(x.Name, term, CompareOptions.IgnoreCase) >= 0));
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

        [HttpGet("{id}/Section")]
        public IActionResult GetSection(string id)
        {
            var mountain = _domainRoot.Mountains.GetById(id);

            if (mountain == null)
                return NotFound();

            return new ObjectResult(_domainRoot.Sections.GetById(mountain.SectionId));
        }

        [HttpGet("{id}/Country")]
        public IActionResult GetCountry(string id)
        {
            var mountain = _domainRoot.Mountains.GetById(id);

            if (mountain == null)
                return NotFound();

            return new ObjectResult(_domainRoot.Countries.GetById(mountain.CountryId));
        }
    }
}
