using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ScotlandsMountains.Domain;
using Microsoft.Extensions.Options;

namespace ScotlandsMountains.Web.Server.Controllers
{
    [Route("api/[controller]")]
    public class StaticDataController : DomainRootController
    {
        readonly Configuration _configuration;

        public StaticDataController(IDomainRoot domainRoot, IOptions<Configuration> configuration)
            :base(domainRoot)
        {
            _configuration = configuration.Value;
        }

        public IActionResult Get()
        {
            return new ObjectResult(new
            {
                ApiBaseUrl = _configuration.ApiBaseUrl,
                Lists = DomainRoot.Lists.OrderBy(x => x.Order),
                Sections = DomainRoot.Sections.OrderBy(x => x.Name),
                ApiKeys = new
                {
                    BingMaps = _configuration.BingMaps.ApiKey,
                    MapBox = _configuration.Mapbox.ApiKey,
                    Recaptcha = _configuration.Recaptcha.SiteKey
                }
            });
        }
    }
}