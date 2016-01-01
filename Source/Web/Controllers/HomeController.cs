using System.Web.Mvc;

namespace ScotlandsMountains.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return PartialView();
        }
    }
}
