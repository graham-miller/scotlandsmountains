using Microsoft.AspNetCore.Mvc;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Web.Controllers
{
    [Route("api/[controller]")]
    public class SectionsController : DomainRootController
    {
        public SectionsController(IDomainRoot domainRoot) : base(domainRoot) { }

        [HttpGet()]
        public IActionResult Get()
        {
            return new ObjectResult(DomainRoot.Sections);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var section = DomainRoot.Sections.GetById(id);

            if (section == null)
                return NotFound();

            return new ObjectResult(section);
        }
    }
}
