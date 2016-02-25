using System;
using System.IO;
using System.Reflection;
using ScotlandsMountains.Importer.DatabaseOfBritishAndIrishHills;

namespace ScotlandsMountains.Importer
{
    public static class ImportConfiguration
    {
        private const string DobihFolder = @"\DatabaseOfBritishAndIrishHills";
        private const string FirebaseFolder = @"\FirebaseData";
        private const string OrdnanceSurveyFolder = @"\OrdnanceSurvey";
        private const string SearchFolder = @"\SearchData";

        private static readonly string DocsFolder = new DirectoryInfo(Assembly.GetExecutingAssembly().Location).Parent.Parent.Parent.Parent.Parent.Parent.FullName + @"\Docs";

        public static string DobihCsvPath => DocsFolder + DobihFolder + @"\DoBIH_v15.1.csv";

        public static string FirebaseJsonPath => DocsFolder + FirebaseFolder + @"\firebase.json";

        public static string SearchJsonPath => DocsFolder + SearchFolder + @"\search.json";

        public static string ExplorerTxtPath => DocsFolder + OrdnanceSurveyFolder + @"\explorer.txt";

        public static string ExplorerActiveTxtPath => DocsFolder + OrdnanceSurveyFolder + @"\explorer-active.txt";

        public static string LandrangerTxtPath => DocsFolder + OrdnanceSurveyFolder + @"\landranger.txt";

        public static string LandrangerActiveTxtPath => DocsFolder + OrdnanceSurveyFolder + @"\landranger-active.txt";

        public static Func<Record, bool> DobihFilter
        {
            get { return record => record[Field.Country] == "S" || record[Field.Country] == "ES"; }
        }
    }
}