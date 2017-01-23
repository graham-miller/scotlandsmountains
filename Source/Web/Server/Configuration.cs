using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScotlandsMountains.Web.Server
{
    public class Configuration
    {
        public string EmailAddress { get; set; }
        public MailGunConfiguration MailGun { get; set; }
    }

    public class MailGunConfiguration
    {
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
        public string DomainName { get; set; }
    }
}
