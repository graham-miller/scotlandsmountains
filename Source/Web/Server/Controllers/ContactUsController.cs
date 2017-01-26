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

        [HttpPost("{send}")]
        public IActionResult Send([FromBody]ContactUsModel model)
        {
            if (!ModelState.IsValid)
            {
                model.SenderErrorText = ModelState?["Sender"]?.Errors?[0]?.ErrorMessage;
                model.SubjectErrorText = ModelState?["Subject"]?.Errors?[0]?.ErrorMessage;
                model.MessageErrorText = ModelState?["Message"]?.Errors?[0]?.ErrorMessage;
                return new BadRequestObjectResult(model);
            }

            try
            {
                _emailHelper.SendEmailToAdmin(model.Subject, $"From: {model.Sender}{Environment.NewLine}{Environment.NewLine}{model.Subject}");
                model.Sent = true;
            }
            catch
            {
                model.Error = true;
            }

            return new OkObjectResult(model);
        }
    }
}