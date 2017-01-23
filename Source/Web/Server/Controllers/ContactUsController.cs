using Microsoft.AspNetCore.Mvc;
using ScotlandsMountains.Web.Server.Helpers;
using ScotlandsMountains.Web.Server.Models;

namespace ScotlandsMountains.Web.Server.Controllers
{
    [Route("api/[controller]")]
    public class ContactUsController : Controller
    {
        private readonly IEmailHelper _emailHelper;

        public ContactUsController(IEmailHelper emailHelper)
        {
            _emailHelper = emailHelper;
        }

        [HttpPost("{send}")]
        public IActionResult Send([FromForm] ContactUsModel model)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(model);
            }

            _emailHelper.SendEmail("graham.miller@hymans.co.uk", "Test subject", "Test body");

            return new OkResult();
        }
    }
}