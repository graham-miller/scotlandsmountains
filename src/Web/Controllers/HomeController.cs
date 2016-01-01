using System.Web.Mvc;

namespace ScotlandsMountains.Web.Controllers
{
    [RoutePrefix("Home")]
    [Route("{action}")]
    public class HomeController : Controller
    {
        [Route("~/")]
        [Route]
        [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }
	}
}