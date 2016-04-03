using System.Web.Http;
using System.Web.Http.Cors;

namespace ScotlandsMountains.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            var cors = new EnableCorsAttribute("https://scotlandsmountains.net", "*", "*");
            config.EnableCors(cors);
        }
    }
}
