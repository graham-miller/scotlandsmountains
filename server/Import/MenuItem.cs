using System;

namespace ScotlandsMountains.Import
{
    internal class MenuItem
    {
        public event EventHandler SelectedEvent;

        public MenuItem(string name, EventHandler selectHandler, IConsole console)
        {
            _console = console;
            Name = name;
            SelectedEvent += selectHandler;
        }

        public string Name { get; }

        public void Select()
        {
            SelectedEvent?.Invoke(this, new EventArgs());
        }

        private readonly IConsole _console;
    }
}
