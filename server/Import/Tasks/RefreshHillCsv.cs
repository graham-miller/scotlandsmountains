using System.IO;
using System.IO.Compression;
using System.Net;
using ScotlandsMountains.Resources;

namespace ScotlandsMountains.Import.Tasks
{
    internal static class HillCsv
    {
        public static void Download()
        {
            using (var web = new WebClient())
            using (var zipStream = new MemoryStream(web.DownloadData(Configuration.HillCsvUrl)))
            using (var zipArchive = new ZipArchive(zipStream, ZipArchiveMode.Read, false))
            using (var file = new FileStream(FileHelper.HillCsvPath, FileMode.Create))
            {
                zipArchive.Entries[0].Open().CopyTo(file);
            }
        }
    }
}