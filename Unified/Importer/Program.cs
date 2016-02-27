using FireSharp;
using FireSharp.Config;
using System;
using System.Diagnostics;

namespace ScotlandsMountains.Importer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("In progress ({0})...", FormattedNow());

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            //ClearFirebase();
            RunImportProcess();

            stopwatch.Start();

            Console.WriteLine("Complete ({0}), in {1}s", FormattedNow(), Math.Round((double)(stopwatch.ElapsedMilliseconds / 1000)).ToString("#,##0"));
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }

        private static void ClearFirebase()
        {
            var firebaseConfig = new FirebaseConfig
            {
                AuthSecret = "",
                BasePath = "https://scotlandsmountains.firebaseio.com/"
            };

            using (var client = new FirebaseClient(firebaseConfig))
            {
                client.Delete("");
            }
        }

        private static void RunImportProcess()
        {
            new ImportProcess().Run();
        }

        private static string FormattedNow()
        {
            return DateTime.Now.ToString("h:mm") + DateTime.Now.ToString("tt").ToLower();
        }
    }
}
