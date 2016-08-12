using System;
using System.Collections.Generic;
using System.IO;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Import
{
    internal class OsFile
    {
        public OsFile()
        {
            Lines = new OsFileReader().ReadLines();

            //WriteToFile();

            var parser = new OsFileParser2(this);
        }

        public readonly IList<string> Lines;

        public IList<Map> LandrangerMaps { get; set; } = new List<Map>();
        public IList<Map> LandrangerActiveMaps { get; set; } = new List<Map>();
        public IList<Map> ExplorerMaps { get; set; } = new List<Map>();
        public IList<Map> ExplorerActiveMaps { get; set; } = new List<Map>();
        public IList<Map> DiscovererMaps { get; set; } = new List<Map>();
        public IList<Map> DiscoveryMaps { get; set; } = new List<Map>();

        private void WriteToFile()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "ScotlandsMountainsRawOsData.txt");

            if (File.Exists(path)) File.Delete(path);

            using (var writer = new StreamWriter(path, false))
                foreach (var line in Lines)
                    writer.WriteLine(line);
        }
    }
}
