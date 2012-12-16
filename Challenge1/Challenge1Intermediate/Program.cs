/*
 * [intermediate] Challenge #1
 * http://www.reddit.com/r/dailyprogrammer/comments/pihtx/intermediate_challenge_1/
 */

using System;
using System.Collections.Generic;
using System.Linq;

using Utilities;

namespace Challenge1Intermediate
{
	public class Program
	{
		private static bool _exit;
		private static readonly List<Event> Events = new List<Event>(); 

		public static void Main(string[] args)
		{
			var menu = new Menu();

			var menuItems = new[]
			{
				new MenuItem("List events", ListEvents),
				new MenuItem("Add event", AddEvent),
				new MenuItem("Remove event", RemoveEvent),
				new MenuItem("Exit", Exit)
			};
			foreach (var menuItem in menuItems)
				menu.AddMenuItem(menuItem);

			var choice = 0;
			var success = false;
			var first = true;
			while (!_exit) // In case Environment.Exit fails?
			{
				Console.Clear();
				menu.PrintMenuItems();
				if (success)
					menu.ExecuteActionByIndex(choice - 1);
				else if (!first)
					Console.WriteLine("Invalid option specified, please choose a number from the list of actions");
				else
					first = false;
				Console.Write("Choose a menu item: ");
				string input = Console.ReadLine();
				success = int.TryParse(input, out choice);
			}
		}

		private static void ListEvents()
		{
			if (Events.Count == 0)
				Console.WriteLine("No events have been added");
			else
				foreach (var e in Events)
					Console.WriteLine("#{0}: {1} @ {2}", e.Id, e.Name, e.Hour);
		}

		private static void AddEvent()
		{
			var name = Input.GetInput("Event name?", "Invalid event name! Input valid event name:", s => !string.IsNullOrEmpty(s));
			var time = Input.GetInput("Time (hour)?", "Invalid time! Input valid time:", s =>
			{
				int r;
				var b = int.TryParse(s, out r);
				return b;
			});
			int hour = int.Parse(time);
			var e = new Event(name, hour);
			Events.Add(e);
			Events.Sort((first, second) => first.Hour.CompareTo(second.Hour));
		}

		private static void RemoveEvent()
		{
			if (Events.Count == 0)
			{
				Console.WriteLine("No events have been added");
				return;
			}

			ListEvents();

			var input = Input.GetInput("Id of event to remove?", "Please input a valid event Id:", s =>
			{
				int id;
				var b = int.TryParse(s, out id);
				if (!b)
					return false;
				return Events.Any(e => e.Id == id);
			});
			int eventId = int.Parse(input);
			Events.RemoveAll(e => e.Id == eventId);
		}

		private static void Exit()
		{
			_exit = true;
			Environment.Exit(0);
		}
	}
}
