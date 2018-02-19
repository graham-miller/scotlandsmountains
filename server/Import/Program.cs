using System;
using System.Collections.Generic;
using System.IO;
using ScotlandsMountains.Resources;

namespace ScotlandsMountains.Import
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Directory.Exists(FileHelper.BaseDirectory))
                throw new DirectoryNotFoundException("Resource files directory not found");

            Console.HideCursor();
            MainMenu.Display();
        }

        private static readonly IConsole Console = new Console();

        private static readonly TaskRunner TaskRunner = new TaskRunner(Console);

        private static readonly List<MenuItem> MainMenuItems = new List<MenuItem>
        {
            new MenuItem("Download hill CSV", (sender, args) => TaskRunner.DownloadHillCsv(), Console),
            new MenuItem("Process hill CSV", (sender, args) => TaskRunner.ProcessHillCsv(), Console)
        };

        private static readonly Menu MainMenu = new Menu("Main menu", MainMenuItems, Console);
    }
}
