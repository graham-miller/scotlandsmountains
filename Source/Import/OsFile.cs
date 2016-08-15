using System;
using System.Collections.Generic;
using System.IO;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Import
{
    public class OsFile
    {
        public OsFile(IOsFileReader osFileReader, IOsFileParser oSFileParser, bool debug = false)
        {
            Lines = osFileReader.ReadLines();

            if (debug) WriteLineToFile();

            oSFileParser.Parse(this);

            if (debug) WriteRecordsToFile();
        }

        public readonly IList<string> Lines;

        public IList<Map> LandrangerMaps { get; set; } = new List<Map>();
        public IList<Map> LandrangerActiveMaps { get; set; } = new List<Map>();
        public IList<Map> ExplorerMaps { get; set; } = new List<Map>();
        public IList<Map> ExplorerActiveMaps { get; set; } = new List<Map>();
        public IList<Map> DiscovererMaps { get; set; } = new List<Map>();
        public IList<Map> DiscoveryMaps { get; set; } = new List<Map>();

        private void WriteLineToFile()
        {
            var path = GetPathToFileOnDesktopAndDeleteIfExisting("ScotlandsMountainsRawOsData.txt");

            using (var writer = new StreamWriter(path, false))
                foreach (var line in Lines)
                    writer.WriteLine(line);
        }

        private void WriteRecordsToFile()
        {
            var path = GetPathToFileOnDesktopAndDeleteIfExisting("ScotlandsMountainsOsData.csv");

            using (var writer = new StreamWriter(path, false))
            {
                // header:
                writer.WriteLine("Publisher,Series,Code,Name,Isbn,Scale");

                WriteRecordsToFile(writer, LandrangerMaps);
                WriteRecordsToFile(writer, LandrangerActiveMaps);
                WriteRecordsToFile(writer, ExplorerMaps);
                WriteRecordsToFile(writer, ExplorerActiveMaps);
                WriteRecordsToFile(writer, DiscovererMaps);
                WriteRecordsToFile(writer, DiscoveryMaps);
            }
        }

        private void WriteRecordsToFile(StreamWriter writer, IList<Map> maps)
        {
            foreach (var map in maps)
                writer.WriteLine("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",{5}", map.Publisher, map.Series, map.Code, map.Name, map.Isbn, map.Scale);
        }

        private static string GetPathToFileOnDesktopAndDeleteIfExisting(string fileName)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), fileName);

            if (File.Exists(path))
                File.Delete(path);

            return path;
        }
    }
}
