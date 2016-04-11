using System;
using System.Web.Http;
using ScotlandsMountains.Api.Models;
using RestSharp;
using RestSharp.Authenticators;

namespace ScotlandsMountains.Api.Controllers
{
    public class ContactUsController : ApiController
    {
        [HttpPost, Route("api/contactus")]
        public IHttpActionResult SendEmail(ContactUsModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                Send("test@example.com", "The subject", "The body");
            }
            catch (Exception)
            {
                return InternalServerError();
            }

            return Ok();
        }

        public static IRestResponse Send(string from, string subject, string text)
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator = new HttpBasicAuthenticator("api", "API_KEY");
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "scotlandsmountains.net", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", from);
            request.AddParameter("to", "graham@scotlandsmountains.net");
            request.AddParameter("subject", subject);
            request.AddParameter("text", text);
            request.Method = Method.POST;
            return client.Execute(request);
        }
    }
}