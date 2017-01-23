using System;
using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Authenticators;

namespace ScotlandsMountains.Web.Server.Helpers
{
    public interface IEmailHelper
    {
        bool IsValidEmailAddress(string emailAddress);
        void SendEmail(string recipient, string subject, string body);
    }

    public class EmailHelper : IEmailHelper
    {
        private readonly Configuration _configuration;

        public EmailHelper(IOptions<Configuration> configuration)
        {
            _configuration = configuration.Value;
        }

        public bool IsValidEmailAddress(string emailAddress)
        {
            // TODO validate email address
            return true;
        }

        public void SendEmail(string recipient, string subject, string body)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri(_configuration.MailGun.BaseUrl),
                Authenticator = new HttpBasicAuthenticator("api", _configuration.MailGun.ApiKey)
            };

            var request = new RestRequest();
            request.AddParameter("domain", _configuration.MailGun.DomainName, ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", _configuration.EmailAddress);
            request.AddParameter("to", recipient);
            request.AddParameter("subject", subject);
            request.AddParameter("text", body);
            request.Method = Method.POST;

            client.Execute(request);
        }
    }
}
