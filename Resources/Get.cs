using System.IO;
using System.Reflection;

namespace ScotlandsMountains.Resources
{
    public static class Get
    {
        private static readonly string BaseNamespace = typeof(Get).Namespace;
        private static readonly string DobihNamespace = BaseNamespace + @".DatabaseOfBritishAndIrishHills";
        private static readonly string OrdnanceSurveyNamespace = BaseNamespace + @".OrdnanceSurvey";
        private static readonly string SearchDataNamespace = BaseNamespace + @".SearchData";

        public static Stream DobihCsv => GetManifestResourceStream(DobihNamespace + ".DoBIH_v15.1.csv");

        public static Stream SearchJson => GetManifestResourceStream(SearchDataNamespace + ".search.json");

        public static Stream ExplorerTxt => GetManifestResourceStream(OrdnanceSurveyNamespace + ".explorer.txt");

        public static Stream ExplorerActiveTxt => GetManifestResourceStream(OrdnanceSurveyNamespace + ".explorer-active.txt");

        public static Stream LandrangerTxt => GetManifestResourceStream(OrdnanceSurveyNamespace + ".landranger.txt");

        public static Stream LandrangerActiveTxt => GetManifestResourceStream(OrdnanceSurveyNamespace + ".landranger-active.txt");

        private static Stream GetManifestResourceStream(string name)
        {
            return Assembly.GetExecutingAssembly().GetManifestResourceStream(name);
        }
    }
}
