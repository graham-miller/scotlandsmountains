using System;
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

        // Idealy we would want to POST, but because of Azure/Cloudflare/Github set up to enable
        // custom domain and https which use redirects, we need to use get 
        // [HttpPost("{send}")]
        // public IActionResult Send([FromBody]ContactUsModel model)
        [HttpGet("{send}")]
        public IActionResult Send([FromQuery]ContactUsModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _emailHelper.SendEmailToAdmin(model.Subject, $"From: {model.Sender}{Environment.NewLine}{Environment.NewLine}{model.Message}");
                    return new OkResult();
                }
                catch
                {
                    return new StatusCodeResult(500);
                }
            }

            return new BadRequestResult();
        }
    }
}