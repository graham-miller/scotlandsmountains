using System;
using System.Collections.Generic;
using System.IO;
using ScotlandsMountains.Import.Tasks;
using ScotlandsMountains.Resources;

namespace ScotlandsMountains.Import
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Directory.Exists(FileHelper.BaseDirectory))
                throw new DirectoryNotFoundException("Resource files directory not found");

            var exit = false;
            MainMenu.ExitEvent += (sender, eventArgs) => exit = true;

            while (!exit)
            {
                Console.CursorVisible = false;

                MainMenu.Display();
                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.Enter:
                        MainMenu.SelectHighlighted();
                        break;
                    case ConsoleKey.UpArrow:
                        MainMenu.HighlightPreviousItem();
                        break;
                    case ConsoleKey.DownArrow:
                        MainMenu.HighlightNextItem();
                        break;
                    default:
                        continue;
                }
            }
        }

        private static readonly Menu MainMenu = new Menu("Main menu", new List<MenuItem>
        {
            new MenuItem("Download hill CSV", (sender, args) => HillCsv.Download())
        });
    }
}
