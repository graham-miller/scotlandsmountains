using Microsoft.AspNet.Mvc;
using ScotlandsMountains.Domain.Abstractions;
using System.Linq;
using System;
using ScotlandsMountains.Web.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ScotlandsMountains.Web.Controllers
{
    public class MountainController : Controller
    {
        [FromServices]
        public IDomainRoot DomainRoot { get; set; }

        [HttpGet, Route("api/[controller]/{key}")]
        public JsonResult Index(string key)
        {
            var result = Result.Create(DomainRoot.Mountains.SingleOrDefault(x => x.Key == key));

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            };

            return new JsonResult(result, settings);
        }
    }
}
