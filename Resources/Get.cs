using System.IO;
using System.Reflection;

namespace ScotlandsMountains.Resources
{
    public static class Get
    {
        private static readonly string BaseNS = typeof(Get).Namespace;
        private static readonly string DobihNS = BaseNS + @".DatabaseOfBritishAndIrishHills";
        private static readonly string OrdnanceSurveyNS = BaseNS + @".OrdnanceSurvey";
        private static readonly string SearchDataNS = BaseNS + @"SearchData";

        public static Stream DobihCsv => GetManifestResourceStream(DobihNS + ".DoBIH_v15.1.csv");

        public static Stream SearchJson => GetManifestResourceStream(SearchDataNS + ".search.json");

        public static Stream ExplorerTxt => GetManifestResourceStream(OrdnanceSurveyNS + ".explorer.txt");

        public static Stream ExplorerActiveTxt => GetManifestResourceStream(OrdnanceSurveyNS + ".explorer-active.txt");

        public static Stream LandrangerTxt => GetManifestResourceStream(OrdnanceSurveyNS + ".landranger.txt");

        public static Stream LandrangerActiveTxt => GetManifestResourceStream(OrdnanceSurveyNS + ".landranger-active.txt");

        private static Stream GetManifestResourceStream(string name)
        {
            return Assembly.GetExecutingAssembly().GetManifestResourceStream(name);
        }
    }
}
