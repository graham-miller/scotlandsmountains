using System;
using System.IO;
using System.Reflection;
using ScotlandsMountains.Import.ConsoleApp.DatabaseOfBritishAndIrishHills;

namespace ScotlandsMountains.Import.ConsoleApp
{
    public static class ImportConfiguration
    {
        private static readonly string DocsFolder = new DirectoryInfo(Assembly.GetExecutingAssembly().Location).Parent.Parent.Parent.Parent.Parent.Parent.FullName + @"\Docs";

        private const string DobihFolder = @"\DatabaseOfBritishAndIrishHills";
        private const string FirebaseFolder = @"\FirebaseData";
        private const string OrdnanceSurveyFolder = @"\OrdnanceSurvey";

        public static string DobihCsvPath
        {
            get { return DocsFolder + DobihFolder + @"\DoBIH_v15.1.csv"; }
        }

        public static string FirebaseJsonPath
        {
            get { return DocsFolder + FirebaseFolder + @"\firebase.json"; }
        }

        public static string ExplorerTxtPath
        {
            get { return DocsFolder + OrdnanceSurveyFolder + @"\explorer.txt"; }
        }

        public static string ExplorerActiveTxtPath
        {
            get { return DocsFolder + OrdnanceSurveyFolder + @"\explorer-active.txt"; }
        }

        public static string LandrangerTxtPath
        {
            get { return DocsFolder + OrdnanceSurveyFolder + @"\landranger.txt"; }
        }

        public static string LandrangerActiveTxtPath
        {
            get { return DocsFolder + OrdnanceSurveyFolder + @"\landranger-active.txt"; }
        }

        public static Func<Record, bool> DobihFilter
        {
            get { return record => record[Field.Country] == "S" || record[Field.Country] == "ES"; }
        }
    }
}