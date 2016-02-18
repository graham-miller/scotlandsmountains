using System;
using ScotlandsMountains.ImportConsole.DatabaseOfBritishAndIrishHills.EntityFactories;

namespace ScotlandsMountains.ImportConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reading file <{0}>...", ImportConfiguration.DobihCsvPath);

            var records = new DatabaseOfBritishAndIrishHills.Reader(ImportConfiguration.DobihCsvPath, ImportConfiguration.DobihFilter).Read();
            var maps = new OrdnanceSurvey.Reader(ImportConfiguration.ExplorerTxtPath, ImportConfiguration.ExplorerActiveTxtPath, ImportConfiguration.LandrangerTxtPath, ImportConfiguration.LandrangerActiveTxtPath).Read();
            var factory = new EntityFactory(records, maps);
            factory.CreateFirebaseJson(ImportConfiguration.FirebaseJsonPath);

            Console.WriteLine("Record count: {0}", records.Count.ToString("#,##0"));

            Console.WriteLine("Press any key to exit:");
            Console.ReadKey(true);
        }
    }
}
