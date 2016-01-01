using System.Web;
using System.Web.Optimization;

namespace ScotlandsMountains.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            CreateJQueryBundle(bundles);
            CreateStyleBundle(bundles);
            CreateFontAwesomeBundle(bundles);
            CreateScotlandsMountainsScriptBundle(bundles);

#if !DEBUG
            OptimizeBundle(bundles);
#endif
        }

        private static void CreateJQueryBundle(BundleCollection bundles)
        {
            bundles
                .Add(new ScriptBundle("~/ScriptBundle/jquery", "//code.jquery.com/jquery-2.1.3.min.js")
                .Include("~/Scripts/jquery-{version}.js"));
        }

        private static void CreateStyleBundle(BundleCollection bundles)
        {
            var bundle = new StyleBundle("~/StyleBundle/css")
                .Include(
                    "~/Styles/reset.css",
                    "~/Styles/base.less",
                    "~/Styles/layout.less",
                    "~/Styles/modules.less");

            bundle.Transforms.Add(new LessTransform());
            bundle.Transforms.Add(new CssMinify());
            
            bundles.Add(bundle); 
        }

        private static void CreateFontAwesomeBundle(BundleCollection bundles)
        {
            bundles
                .Add(new StyleBundle("~/StyleBundle/fontawesome", "//maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css")
                .Include("~/Styles/font-awesome.css"));
        }

        private static void CreateScotlandsMountainsScriptBundle(BundleCollection bundles)
        {
            var bundle = new ScriptBundle("~/ScriptBundle/scotlandsmountains")
                .Include(
                    "~/Scripts/finch-{version}.js",
                    "~/Scripts/navigation.js",
                    "~/Scripts/routing.js",
                    "~/Scripts/map.js",
                    "~/Scripts/bootstrap.js");

            bundle.Transforms.Add(new JsMinify());

            bundles.Add(bundle);
        }

        private static void OptimizeBundle(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;
            bundles.UseCdn = true;
        }
    }

    public class LessTransform : IBundleTransform
    {
        public void Process(BundleContext context, BundleResponse response)
        {
            response.Content = dotless.Core.Less.Parse(response.Content);
            response.ContentType = "text/css";
        }
    }
}
