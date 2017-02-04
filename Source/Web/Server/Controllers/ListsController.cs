using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ScotlandsMountains.Domain;
using Microsoft.Extensions.Options;

namespace ScotlandsMountains.Web.Server.Controllers
{
    [Route("api/[controller]")]
    public class StaticDataController
    {
        IDomainRoot _domainRoot;
        IOptions<Configuration> _configuration;

        public StaticDataController(IDomainRoot domainRoot, IOptions<Configuration> configuration)
        {
            _domainRoot = domainRoot;
            _configuration = configuration;
        }

        public IActionResult Get()
        {
            return new ObjectResult(new
            {
                Lists = _domainRoot.Lists.OrderBy(x => x.Order),
                Sections = _domainRoot.Sections.OrderBy(x => x.Name),
                ApiKeys = new
                {
                    BingMaps = _configuration.Value.BingMaps.ApiKey,
                    MapBox = _configuration.Value.Mapbox.ApiKey
                }
            });
        }
    }
}