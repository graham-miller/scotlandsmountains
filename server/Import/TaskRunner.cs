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

        public void RefreshRawData()
        {
            RunTask(() =>
            {
                _console.WriteLine($"Downloading from {Configuration.HillCsvUrl}...");
                using (var web = new WebClient())
                using (var zipStream = new MemoryStream(web.DownloadData(Configuration.HillCsvUrl)))
                using (var zipArchive = new ZipArchive(zipStream, ZipArchiveMode.Read, false))
                using (var file = new FileStream(FileHelper.HillCsvPath, FileMode.Create))
                {
                    zipArchive.Entries[0].Open().CopyTo(file);
                }
            });
        }

        public void GenerateRootFile()
        {
            RunTask(() =>
            {
                _console.WriteLine("Loading CSV...");
                var records = HillCsvParser.Parse();

                _console.WriteLine("Building root...");
                var root = Root.CreateFrom(records);

                _console.WriteLine("Writing root out to file...");
                var json = root.ToJson();
                File.WriteAllText(FileHelper.RootJsonPath, json);
            });
        }

        public void GenerateCacheFiles()
        {
            RunTask(() =>
            {
                _console.WriteLine("Loading root from file...");
                var json = File.ReadAllText(FileHelper.RootJsonPath);
                var root = Root.LoadFromJson(json);


            });
        }

        private void RunTask(Action task)
        {
            task();
            _console.WriteLine("Complete, press any key to continue.");
            _console.WaitForAnyKey();
        }

        private readonly IConsole _console;
    }
}