using FireSharp;
using FireSharp.Config;
using System;
using System.Diagnostics;

namespace ScotlandsMountains.Import.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("In progress ({0})...", FormattedNow());

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            //ClearFirebase();
            CreateFirebaseJson();

            stopwatch.Start();

            Console.WriteLine("Complete ({0}), in {1}s", FormattedNow(), Math.Round((double)(stopwatch.ElapsedMilliseconds / 1000)).ToString("#,##0"));
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }

        private static void ClearFirebase()
        {
            using (var client = new FirebaseClient(new FirebaseConfig
            {
                AuthSecret = "",
                BasePath = "https://scotlandsmountains.firebaseio.com/"
            }))
            {
                client.Delete("");
            }
        }

        private static void CreateFirebaseJson()
        {
            new Importer().Import();
        }

        private static string FormattedNow()
        {
            return DateTime.Now.ToString("h:mm") + DateTime.Now.ToString("tt").ToLower();
        }
    }
}
