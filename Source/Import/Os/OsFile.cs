using System;
using System.Collections.Generic;
using System.IO;

namespace ScotlandsMountains.Import.Os
{
    public interface IOsFile
    {
        IList<OsRecord> Landranger { get; }
        IList<OsRecord> LandrangerActive { get; }
        IList<OsRecord> Explorer { get; }
        IList<OsRecord> ExplorerActive { get; }
        IList<OsRecord> Discoverer { get; }
        IList<OsRecord> Discovery { get; }
    }

    public class OsFile : IOsFile
    {
        public OsFile(IOsFileReader osFileReader = null, IOsFileParser osFileParser = null, bool debug = false)
        {
            osFileReader = osFileReader ?? new OsFileReader();
            osFileParser = osFileParser ?? new OsFileParser();

            Lines = osFileReader.Lines;

            if (debug) WriteLineToFile();

            osFileParser.Parse(this);

            if (debug) WriteRecordsToFile();
        }

        public IList<string> Lines { get; }

        public IList<OsRecord> Landranger { get;} = new List<OsRecord>();
        public IList<OsRecord> LandrangerActive { get;} = new List<OsRecord>();
        public IList<OsRecord> Explorer { get; } = new List<OsRecord>();
        public IList<OsRecord> ExplorerActive { get; } = new List<OsRecord>();
        public IList<OsRecord> Discoverer { get; } = new List<OsRecord>();
        public IList<OsRecord> Discovery { get; } = new List<OsRecord>();

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

                WriteRecordsToFile(writer, Landranger);
                WriteRecordsToFile(writer, LandrangerActive);
                WriteRecordsToFile(writer, Explorer);
                WriteRecordsToFile(writer, ExplorerActive);
                WriteRecordsToFile(writer, Discoverer);
                WriteRecordsToFile(writer, Discovery);
            }
        }

        private void WriteRecordsToFile(StreamWriter writer, IList<OsRecord> maps)
        {
            foreach (var map in maps)
                writer.WriteLine("\"{0}\",\"{1}\",\"{2}\"", map.Code, map.Name, map.Isbn);
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
