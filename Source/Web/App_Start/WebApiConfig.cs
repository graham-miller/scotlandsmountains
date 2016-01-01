using System.Web.Http;

namespace ScotlandsMountains.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "MountainApiSearch",
                routeTemplate: "api/mountains/search",
                defaults: new { controller = "Mountains", action = "Search" }
            );

            config.Routes.MapHttpRoute(
                name: "MountainApiMunros",
                routeTemplate: "api/mountains/munros",
                defaults: new { controller = "Mountains", action = "Munros" }
            );

            config.Routes.MapHttpRoute(
                name: "MountainApiCorbetts",
                routeTemplate: "api/mountains/corbetts",
                defaults: new { controller = "Mountains", action = "Corbetts" }
            );

            config.Routes.MapHttpRoute(
                name: "MountainApiGrahams",
                routeTemplate: "api/mountains/grahams",
                defaults: new { controller = "Mountains", action = "Grahams" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}
