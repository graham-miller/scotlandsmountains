using System;
using System.IO;
using System.Reflection;
using ScotlandsMountains.ImportConsole.Dobih;
using ScotlandsMountains.ImportConsole.Dobih.EntityFactories;

namespace ScotlandsMountains.ImportConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reading file <{0}>...", GetPathToDobihCsv());

            var records = new Reader(GetPathToDobihCsv(), GetDobihFilter()).Read();
            var factory = new EntityFactory(records);
            factory.CreateFirebaseJson(GetPathToFirebaseJson());

            Console.WriteLine("Record count: {0}", records.Count.ToString("#,##0"));

            Console.WriteLine("Press any key to exit:");
            Console.ReadKey(true);
        }

        private static string GetPathToDobihCsv()
        {
            return GetDocsFolder() + @"\DatabaseOfBritishAndIrishHills\DoBIH_v15.1.csv";
        }

        private static string GetPathToFirebaseJson()
        {
            return GetDocsFolder() + @"\FirebaseData\firebase.json";
        }

        private static string GetDocsFolder()
        {
            return new DirectoryInfo(Assembly.GetExecutingAssembly().Location)
                .Parent.Parent.Parent.Parent.Parent.Parent.FullName
                + @"\Docs";
        }

        private static Func<Record, bool> GetDobihFilter()
        {
            return record => record[Field.Country] == "S" || record[Field.Country] == "ES";
        }
    }
}
