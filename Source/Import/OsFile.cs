using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Import
{
    internal class OsFile
    {
        public OsFile()
        {
            Lines = new OsFileReader().ReadLines();

            //WriteToFile();

            var parser = new OsFileParser(this);
        }

        public readonly IList<string> Lines;

        public IList<Map> LandrangerMaps { get; set; } = new List<Map>();
        public IList<Map> LandrangerActiveMaps { get; set; } = new List<Map>();
        public IList<Map> ExplorerMaps { get; set; } = new List<Map>();
        public IList<Map> ExplorerActiveMaps { get; set; } = new List<Map>();
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

/*
Landranger Title ISBN Pub date Edn Revised Date

1
Shetland – Yell, Unst and
Fetlar 9780319260999 24/02/16
Feb
2016 May 2015

Leisure map catalogue
v1.51 © Crown copyright
Page 5 of 60
*/