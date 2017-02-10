using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ScotlandsMountains.Web.Server.Helpers;
using ScotlandsMountains.Web.Server.Models;

namespace ScotlandsMountains.Web.Server.Controllers
{
    [Route("api/[controller]")]
    public class ContactUsController : Controller
    {
        private readonly IEmailHelper _emailHelper;
        private readonly Configuration _configuration;

        public ContactUsController(IEmailHelper emailHelper, IOptions<Configuration> configuration)
        {
            _emailHelper = emailHelper;
            _configuration = configuration.Value;
        }

        [HttpPost("{send}")]
        public IActionResult Send([FromBody]ContactUsModel model)
        {
            if (!ModelState.IsValid) return new BadRequestResult();

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var url = new Uri("https://www.google.com/recaptcha/api/siteverify");

                    var requestJson = JsonConvert.SerializeObject(new
                    {
                        secret = _configuration.Recaptcha.SecretKey,
                        response = model.GRecaptchaResponse
                    });
                    var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

                    var response = client.PostAsync(url, content).Result;

                    if (!response.IsSuccessStatusCode) return new StatusCodeResult(500);

                    var responseJson = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<dynamic>(responseJson);

                    if (!result.Success) return new StatusCodeResult(500);
                }

                _emailHelper.SendEmailToAdmin(model.Subject, $"From: {model.Sender}{Environment.NewLine}{Environment.NewLine}{model.Message}");
                return new OkResult();
            }
            catch
            {
                return new StatusCodeResult(500);
            }
        }
    }
}