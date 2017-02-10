using System;
using Microsoft.AspNetCore.Mvc;
using ScotlandsMountains.Web.Server.Helpers;
using ScotlandsMountains.Web.Server.Models;
using System.Threading.Tasks;

namespace ScotlandsMountains.Web.Server.Controllers
{
    [Route("api/[controller]")]
    public class ContactUsController : Controller
    {
        private readonly IEmailHelper _emailHelper;
        private readonly IRecaptchaHelper _recaptchaHelper;

        public ContactUsController(IEmailHelper emailHelper,  IRecaptchaHelper recaptchaHelper)
        {
            _emailHelper = emailHelper;
            _recaptchaHelper = recaptchaHelper;
        }

        [HttpPost("{send}")]
        public async Task<IActionResult> Send([FromBody]ContactUsModel model)
        {
            if (!ModelState.IsValid) return new BadRequestResult();

            try
            {
                if (await _recaptchaHelper.IsValidAsync(model.GRecaptchaResponse))
                {
                    var body = $"From: {model.Sender}{Environment.NewLine}{Environment.NewLine}{model.Message}";
                    _emailHelper.SendEmailToAdmin(model.Subject, body);
                    return new OkResult();
                }

                return new StatusCodeResult(500);
            }
            catch
            {
                return new StatusCodeResult(500);
            }
        }
    }

}