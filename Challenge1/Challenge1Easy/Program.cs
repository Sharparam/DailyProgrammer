using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1Easy
{
	class Program
	{
		private const string SaveFile = "data.txt";
		
		private static string _name;
		private static int _age;
		private static string _reddit;

		static void Main(string[] args)
		{
			if (File.Exists(SaveFile))
			{
				Console.Write("Load data from file? ");
				var input = Console.ReadLine();
				char choice = string.IsNullOrEmpty(input) ? 'N' : input.ToUpper()[0];
				if (choice == 'Y')
				{
					var lines = File.ReadAllLines(SaveFile);
					if (lines.Length < 3)
					{
						Console.WriteLine("Error: Invalid file structure");
						Environment.Exit(1);
					}
					_name = lines[0];
					_age = int.Parse(lines[1]);
					_reddit = lines[2];
				}
			}

			if (string.IsNullOrEmpty(_name))
			{
				_name = Utilities.Input.GetInput("What's your name?", "Invalid name, please enter a valid name:", s => !string.IsNullOrEmpty(s));
				var age = Utilities.Input.GetInput("How old are you?", "Invalid age, please enter a valid age:", s =>
				{
					int r;
					var b = int.TryParse(s, out r);
					return b;
				});
				_age = int.Parse(age);
				_reddit = Utilities.Input.GetInput("What's your reddit username?", "Invalid username, please enter a valid username:", s => !string.IsNullOrEmpty(s));
				File.WriteAllLines(SaveFile, new[] {_name, _age.ToString(), _reddit});
			}

			Console.WriteLine("Your name is {0}, you are {1} years old, and your username is {2}.", _name, _age, _reddit);
			Console.WriteLine("This information is saved in {0}", SaveFile);
			Console.ReadLine();
		}
	}
}
