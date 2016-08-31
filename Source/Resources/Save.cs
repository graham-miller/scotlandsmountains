using System.IO;
using System.IO.Compression;

namespace ScotlandsMountains.Resources
{
    public static class Save
    {
        public static class ScotlandsMountains
        {
            public static void DomainJson(string json)
            {
                var path = Paths.DomainZip;
                File.WriteAllText(path, json);

                using (var stream = new FileStream(path, FileMode.Create))
                using (var zip = new ZipArchive(stream, ZipArchiveMode.Create))
                using (var entry = zip.CreateEntry(FileNames.DomainJson).Open())
                using (var writer = new StreamWriter(entry))
                {
                    writer.WriteLine(json);
                }
            }
        }
    }
}
