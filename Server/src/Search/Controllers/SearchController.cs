using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using ScotlandsMountains.Domain.Abstractions;

namespace Search.Controllers
{
    public class SearchController : Controller
    {
        [FromServices]
        public IDomainRoot DomainRoot { get; set; }

        [HttpGet, Route("api/[controller]/{term}")]
        public IEnumerable<string> Index(string term)
        {
            return new [] { term };
        }
    }
}
