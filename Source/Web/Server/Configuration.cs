﻿namespace ScotlandsMountains.Web.Server
{
    public class Configuration
    {
        public EmailAddressConfiguration EmailAddress { get; set; }
        public MailGunConfiguration MailGun { get; set; }
        public BingMapsConfiguration BingMaps { get; set; }
        public MapboxConfiguration Mapbox { get; set; }
    }

    public class EmailAddressConfiguration
    {
        public string NoReply { get; set; }
        public string Admin { get; set; }
    }

    public class MailGunConfiguration
    {
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
        public string DomainName { get; set; }
    }

    public class BingMapsConfiguration
    {
        public string ApiKey { get; set; }
    }

    public class MapboxConfiguration
    {
        public string ApiKey { get; set; }
    }
}
