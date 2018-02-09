using System;

namespace ScotlandsMountains.Import
{
    internal class MenuItem
    {
        public event EventHandler SelectedEvent;

        public MenuItem(string name, EventHandler selectHandler)
        {
            Name = name;
            SelectedEvent += selectHandler;
        }

        public string Name { get; }

        public void Select()
        {
            SelectedEvent?.Invoke(this, new EventArgs());
        }
    }
}
