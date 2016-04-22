using Newtonsoft.Json.Serialization;
using System.Web;
using System.Web.Http;

namespace ScotlandsMountains.Api
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var formatters = GlobalConfiguration.Configuration.Formatters;
            formatters.Remove(formatters.XmlFormatter);

            var serializerSettings = formatters.JsonFormatter.SerializerSettings;
            serializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
