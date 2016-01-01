using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
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