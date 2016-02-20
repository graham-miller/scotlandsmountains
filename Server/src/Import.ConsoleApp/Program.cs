using System;
using System.Diagnostics;

namespace ScotlandsMountains.Import.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Import in progress ({0}).", FormattedNow());

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            new Importer().Import();

            stopwatch.Start();

            Console.WriteLine("Import complete ({0}), in {1}s", FormattedNow(), Math.Round((double)(stopwatch.ElapsedMilliseconds/1000)).ToString("#,##0"));
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }

        private static string FormattedNow()
        {
            return DateTime.Now.ToString("h:mm") + DateTime.Now.ToString("tt").ToLower();
        }
    }
}
