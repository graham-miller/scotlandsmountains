using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Search.Models;
using ScotlandsMountains.Domain.Abstractions;

namespace Search.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        [FromServices]
        public IDomainRoot DomainRoot { get; set; }

        [HttpGet("{term}", Name = "[action]")]
        public IEnumerable<string> GetResults(string term)
        {
            return new string[] { "value1", "value2" };
        }
    }
}
