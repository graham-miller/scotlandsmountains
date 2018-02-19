using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Resources;

namespace ScotlandsMountains.Import
{
    internal class TaskRunner
    {
        public TaskRunner(IConsole console)
        {
            _console = console;
        }

        public void DownloadHillCsv()
        {
            RunTask(() =>
            {
                using (var web = new WebClient())
                using (var zipStream = new MemoryStream(web.DownloadData(Configuration.HillCsvUrl)))
                using (var zipArchive = new ZipArchive(zipStream, ZipArchiveMode.Read, false))
                using (var file = new FileStream(FileHelper.HillCsvPath, FileMode.Create))
                {
                    zipArchive.Entries[0].Open().CopyTo(file);
                }
            }, "Download hill CSV");
        }

        public void ProcessHillCsv()
        {
            RunTask(() =>
            {
                var root = new Root(HillCsvParser.Parse());
            }, "Process hill CSV");
        }

        private void RunTask(Action task, string name)
        {
            _console.WriteLine($"{name} started");
            task();
            _console.WriteLine($"{name} complete, press any key to continue.");
            _console.WaitForAnyKey();
        }

        private readonly IConsole _console;
    }
}