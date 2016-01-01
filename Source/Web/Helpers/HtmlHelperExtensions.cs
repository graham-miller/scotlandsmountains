using System.Configuration;
using System.Web.Mvc;

namespace ScotlandsMountains.Web.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static string ClickyKey(this HtmlHelper htmlHelper)
        {
            return ConfigurationManager.AppSettings["ClickyKey"];
        }
    }
}