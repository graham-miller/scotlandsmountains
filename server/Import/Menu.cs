using System;
using System.Collections.Generic;
using System.Threading;

namespace ScotlandsMountains.Import
{
    internal class Menu
    {
        public Menu(string name, IList<MenuItem> items, IConsole console)
        {
            _name = name;
            _items = items;
            _console = console;
            _items.Add(new MenuItem("Exit", (sender, args) => _exit = true, _console));
            _highlightedItem = items[0];
        }

        public void Display()
        {
            _exit = false;
            while (!_exit)
            {
                DisplayHeader();
                DisplayMenuItems();

                var key = _console.GetKey();

                if (key == ConsoleKey.Enter)
                    SelectHighlighted();
                else if (key == ConsoleKey.UpArrow)
                    HighlightPreviousItem();
                else if (key == ConsoleKey.DownArrow)
                    HighlightNextItem();
            }
        }

        private void DisplayHeader()
        {
            _console.Clear();
            _console.WriteLine(_name);
            _console.WriteLine(new string('=', _name.Length));
            _console.WriteLine();
            _console.WriteLine("Use ↑ and ↓ to change selection and <Enter> to make selection:");
            _console.WriteLine();
        }

        private void DisplayMenuItems()
        {
            var number = 0;
            foreach (var item in _items)
            {
                number++;
                var highlighted = item == _highlightedItem;
                if (highlighted) _console.InvertColors();
                _console.WriteLine($"{(highlighted ? ">" : " ")} {number}. {item.Name}");
                if (highlighted) _console.RevertColors();
            }
            _console.WriteLine();
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
            _highlightedItem.Select();
            Thread.Sleep(250);
        }

        private bool _exit = false;
        private readonly string _name;
        private readonly IList<MenuItem> _items;
        private readonly IConsole _console;
        private MenuItem _highlightedItem;
    }
}
