using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace ScotlandsMountains.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
