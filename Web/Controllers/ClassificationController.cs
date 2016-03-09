using Microsoft.AspNet.Mvc;
using ScotlandsMountains.Domain.Abstractions;
using System.Linq;
using System;
using ScotlandsMountains.Web.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ScotlandsMountains.Web.Controllers
{
    public class ClassificationController : Controller
    {
        [FromServices]
        public IDomainRoot DomainRoot { get; set; }

        [HttpGet, Route("api/[controller]/{classification}/mountains")]
        public JsonResult Mountains(string classification)
        {
            var results = DomainRoot.Mountains
                    .Where(x => x.Classifications.Any(y => string.Equals(y.Name, classification, StringComparison.OrdinalIgnoreCase)))
                    .OrderByDescending(x => x.Height.Metres)
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
