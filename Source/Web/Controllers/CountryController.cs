using Microsoft.AspNetCore.Mvc;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Web.Controllers
{
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        private readonly DomainRoot _domainRoot;

        public CountryController(DomainRoot domainRoot)
        {
            _domainRoot = domainRoot;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            return new ObjectResult(_domainRoot.Countries);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var country = _domainRoot.Countries.GetById(id);

            if (country == null)
                return NotFound();

            return new ObjectResult(country);
        }
    }
}
