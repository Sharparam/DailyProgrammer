using System;
using System.Collections.Generic;

namespace Challenge1Intermediate
{
	internal class Menu
	{
		private readonly List<MenuItem> _items;

		internal Menu()
		{
			_items = new List<MenuItem>();
		}

		internal void AddMenuItem(MenuItem item)
		{
			_items.Add(item);
		}

		internal MenuItem GetMenuItemByIndex(int index)
		{
			if (index < 0 || index >= _items.Count)
				return null;
			return _items[index];
		}

		internal void ExecuteActionByIndex(int index)
		{
			var item = GetMenuItemByIndex(index);
			if (item == null)
				Console.WriteLine("Invalid menu item selected");
			else
				item.Callback();
		}

		internal void PrintMenuItems()
		{
			for (int i = 0; i < _items.Count; i++)
				Console.WriteLine("{0}: {1}", i + 1, _items[i].Name);
		}
	}
}
