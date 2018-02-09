using System;
using System.Collections.Generic;
using System.Threading;

namespace ScotlandsMountains.Import
{
    internal class Menu
    {
        public event EventHandler ExitEvent;

        public Menu(string name, IList<MenuItem> items)
        {
            _name = name;
            _items = items;
            _items.Add(new MenuItem("Exit", (sender, args) => ExitEvent?.Invoke(this, new EventArgs())));
            _highlightedItem = items[0];
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine(_name);
            Console.WriteLine(new string('=', _name.Length));
            Console.WriteLine();
            Console.WriteLine("Use ↑ and ↓ to change selection and <Enter> to make selection:");
            Console.WriteLine();

            foreach (var item in _items)
            {
                var highlighted = item == _highlightedItem;
                if (highlighted) InvertConsole();
                Console.WriteLine($"{(highlighted ? ">" : " ")} {item.Name}");
                if (highlighted) RevertConsole();
            }
            Console.WriteLine();
        }

        public void HighlightNextItem()
        {
            var index = _items.IndexOf(_highlightedItem);

            if (index == _items.Count - 1)
                _highlightedItem = _items[0];
            else
                _highlightedItem = _items[index + 1];
        }

        public void HighlightPreviousItem()
        {
            var index = _items.IndexOf(_highlightedItem);

            if (index == 0)
                _highlightedItem = _items[_items.Count - 1];
            else
                _highlightedItem = _items[index-1];
        }

        public void SelectHighlighted()
        {
            Console.WriteLine($"Started '{_highlightedItem.Name}'...");
            _highlightedItem.Select();
            Console.WriteLine($"Completed '{_highlightedItem.Name}'");
            Thread.Sleep(250);
        }

        private static void InvertConsole()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }

        private static void RevertConsole()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        private readonly string _name;
        private readonly IList<MenuItem> _items;
        private MenuItem _highlightedItem;
    }
}
