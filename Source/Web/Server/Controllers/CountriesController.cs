using Microsoft.AspNetCore.Mvc;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Web.Server.Controllers
{
    [Route("api/[controller]")]
    public class CountriesController : DomainRootController
    {
        public CountriesController(IDomainRoot domainRoot) : base(domainRoot) { }

        [HttpGet()]
        public IActionResult Get()
        {
            return new ObjectResult(DomainRoot.Countries);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var country = DomainRoot.Countries.GetById(id);

            if (country == null)
                return NotFound();

            return new ObjectResult(country);
        }
    }
}
