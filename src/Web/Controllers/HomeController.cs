using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ScotlandsMountains.Data;

namespace ScotlandsMountains.Web.Controllers
{
    [Route("/[controller]"),Route("/")]
    public class HomeController : Controller
    {
        private IScotlandsMountainsContext _context;

        public HomeController(IScotlandsMountainsContext context)
        {
            _context = context;
        }

        [Route("[action]"), Route("")]
        public IActionResult Default()
        {
            return View();
        }
    }
}
