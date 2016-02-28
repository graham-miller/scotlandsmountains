using Microsoft.AspNet.Mvc;
using ScotlandsMountains.Domain.Abstractions;
using System.Linq;
using System;
using ScotlandsMountains.Web.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ScotlandsMountains.Web.Controllers
{
    public class SearchController : Controller
    {
        [FromServices]
        public IDomainRoot DomainRoot { get; set; }

        [HttpGet, Route("api/[controller]/{term}")]
        public JsonResult Index(string term)
        {
            var results = DomainRoot.Mountains
                    .Where(x => x.Name.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0)
                    .OrderByDescending(x => x.Height.Metres)
                    .Take(50)
                    .Select(Result.Create)
                    .ToArray();

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            };

            return new JsonResult(results, settings);
        }
    }
}
