using System;
using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Authenticators;

namespace ScotlandsMountains.Web.Server.Helpers
{
    public interface IEmailHelper
    {
        void SendEmailToAdmin(string subject, string body);
    }

    public class EmailHelper : IEmailHelper
    {
        private readonly Configuration _configuration;

        public EmailHelper(IOptions<Configuration> configuration)
        {
            _configuration = configuration.Value;
        }

        public void SendEmailToAdmin(string subject, string body)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri(_configuration.MailGun.BaseUrl),
                Authenticator = new HttpBasicAuthenticator("api", _configuration.MailGun.ApiKey)
            };

            var request = new RestRequest();
            request.AddParameter("domain", _configuration.MailGun.DomainName, ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", _configuration.EmailAddress.NoReply);
            request.AddParameter("to", _configuration.EmailAddress.Admin);
            request.AddParameter("subject", subject);
            request.AddParameter("text", body);
            request.Method = Method.POST;

            client.Execute(request);
        }
    }
}
