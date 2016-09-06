using Microsoft.AspNetCore.Mvc;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Web.Controllers
{
    [Route("api/[controller]")]
    public class SectionController : Controller
    {
        private readonly DomainRoot _domainRoot;

        public SectionController(DomainRoot domainRoot)
        {
            _domainRoot = domainRoot;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            return new ObjectResult(_domainRoot.Sections);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var section = _domainRoot.Sections.GetById(id);

            if (section == null)
                return NotFound();

            return new ObjectResult(section);
        }
    }
}
