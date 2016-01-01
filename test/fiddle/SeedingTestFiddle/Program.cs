using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Configuration;
using ScotlandsMountains.Data.Seeding;
using ScotlandsMountains.Data;

namespace ScotlandsMountains.SeedingTestFiddle
{
    class Program
    {
        private static readonly Loader.Configuration Configuration = new Loader.Configuration
        {
            DobihCsvPath = new ImportPath(ConfigurationManager.AppSettings["DobihCsvPath"]),
            OsExplorerTxtPath = new ImportPath(ConfigurationManager.AppSettings["OsExplorerTxtPath"]),
            OsExplorerActiveTxtPath = new ImportPath(ConfigurationManager.AppSettings["OsExplorerActiveTxtPath"]),
            OsLandrangerTxtPath = new ImportPath(ConfigurationManager.AppSettings["OsLandrangerTxtPath"]),
            OsLandrangerActiveTxtPath = new ImportPath(ConfigurationManager.AppSettings["OsLandrangerActiveTxtPath"]),
            OsDiscoveryTxtPath = new ImportPath(ConfigurationManager.AppSettings["OsDiscoveryTxtPath"])
        };
        static void Main(string[] args)
        {
            Console.WriteLine("Loading started at {0}", DateTime.Now.ToString("h.mmtt").ToLower());

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var loader = new Loader(Configuration);
            var context = new ScotlandsMountainsContext();
            loader.Load(context);

            stopwatch.Stop();

            Console.WriteLine("Loading completed at {0} in {1}s",
                DateTime.Now.ToString("h.mmtt").ToLower(),
                (stopwatch.ElapsedMilliseconds / 1000).ToString("#,##0"));
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}
