using System;

namespace ScotlandsMountains.Import
{
    internal interface IConsole
    {
        void Clear();
        void WriteLine(string format);
        void WriteLine();
        void InvertColors();
        void RevertColors();
        void HideCursor();
        void WaitForAnyKey();
        ConsoleKey GetKey();
    }

    internal class Console : IConsole
    {
        public void HideCursor()
        {
            System.Console.CursorVisible = false;
        }

        public void Clear()
        {
            System.Console.Clear();
        }

        public void WriteLine()
        {
            System.Console.WriteLine();
        }

        public void WriteLine(string format)
        {
            System.Console.WriteLine(format);
        }

        public void InvertColors()
        {
            System.Console.BackgroundColor = ConsoleColor.White;
            System.Console.ForegroundColor = ConsoleColor.Black;
        }

        public void RevertColors()
        {
            System.Console.BackgroundColor = ConsoleColor.Black;
            System.Console.ForegroundColor = ConsoleColor.White;
        }

        public void WaitForAnyKey()
        {
            System.Console.ReadKey(true);
        }

        public ConsoleKey GetKey()
        {
            return System.Console.ReadKey(true).Key;
        }
    }
}
