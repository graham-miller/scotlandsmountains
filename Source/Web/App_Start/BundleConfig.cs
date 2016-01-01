using System.Web.Optimization;

namespace ScotlandsMountains.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(CreateInternalStyleBundle());
            bundles.Add(CreateFontAwesomeStyleBundle());
            bundles.Add(CreateJQueryUiStyleBundle());
            bundles.Add(CreateScriptJQueryBundle());
            bundles.Add(CreateScriptJQueryUiBundle());
            bundles.Add(CreateAppScriptBundle());

#if !DEBUG
            OptimizeBundle(bundles);
#endif
        }

        private static StyleBundle CreateInternalStyleBundle()
        {
            var styleBundle = new StyleBundle("~/Bundles/Styles/internal");
            styleBundle.Include(
                "~/Styles/reset.css",
                "~/Styles/base.less");
            styleBundle.Transforms.Add(new LessTransform());
            styleBundle.Transforms.Add(new CssMinify());
            return styleBundle;
        }

        private static StyleBundle CreateFontAwesomeStyleBundle()
        {
            var styleBundle = new StyleBundle(
                "~/Bundles/Styles/font-awesome",
                "//maxcdn.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css");
            styleBundle.Include("~/Styles/font-awesome-min.css");
            return styleBundle;
        }

        private static StyleBundle CreateJQueryUiStyleBundle()
        {
            var styleBundle = new StyleBundle(
                "~/Bundles/Styles/jquery-ui",
                "//ajax.aspnetcdn.com/ajax/jquery.ui/1.10.4/themes/smoothness/jquery-ui.css");
            styleBundle.Include("~/Styles/jquery-ui-1.10.4.css");
            return styleBundle;
        }

        private static Bundle CreateScriptJQueryBundle()
        {
            return new ScriptBundle(
                "~/Bundles/Scripts/jquery",
                "//ajax.aspnetcdn.com/ajax/jQuery/jquery-1.11.1.min.js"
                ).Include("~/Scripts/lib/jquery-1.11.1.min.js");
        }

        private static Bundle CreateScriptJQueryUiBundle()
        {
            return new ScriptBundle(
                "~/Bundles/Scripts/jquery-ui",
                "//ajax.aspnetcdn.com/ajax/jquery.ui/1.10.4/jquery-ui.min.js"
                ).Include("~/Scripts/lib/jquery-ui-1.10.4.min.js");
        }

        private static Bundle CreateAppScriptBundle()
        {
            return new ScriptBundle("~/Bundles/Scripts/app")
                .Include("~/Scripts/lib/finch-0.5.14.min.js")
                .Include("~/Scripts/app/layer.js")
                .Include("~/Scripts/app/map.js")
                .Include("~/Scripts/app/dialog.js")
                .Include("~/Scripts/app/toolbar.js")
                .Include("~/Scripts/app/search.js")
                .Include("~/Scripts/app/routing.js")
                .Include("~/Scripts/app/bootstrap.js");
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