/*
 * [difficult] Challenge #1
 * http://www.reddit.com/r/dailyprogrammer/comments/pii6j/difficult_challenge_1/
 */

using System;

namespace Challenge1Difficult
{
	class Program
	{
		private static readonly Random Rand = new Random();
		private static int _number;

		public static void Main(string[] args)
		{
			var input = Utilities.Input.GetInput("Enter a number (1-100):",
			                                     "Invalid number, please enter a number between 1 and 100:", s =>
			                                     {
				                                     int r;
				                                     var b = int.TryParse(s, out r);
				                                     return b;
			                                     });
			_number = int.Parse(input);
			Console.WriteLine("You have chosen the number {0}, I will now try to guess it. Please tell me \"too low\", \"too high\" or \"correct\".", _number);
			bool correct = false;
			int upper = 100;
			int lower = 1;
			while (!correct)
			{
				int guess = Rand.Next(lower, upper + 1);
				Console.WriteLine("Is it {0}?", guess);
				string response = Utilities.Input.GetInput("\"too low\", \"too high\" or \"correct\":",
				                                           "\"too low\", \"too high\" or \"correct\":",
				                                           s =>
				                                           {
					                                           if (string.IsNullOrEmpty(s))
						                                           return false;
					                                           s = s.ToLower();
					                                           if (s != "too low" && s != "too high" && s != "correct")
						                                           return false;
					                                           return true;
				                                           }).ToLower();
				if (response == "too low")
					lower = guess + 1;
				else if (response == "too high")
					upper = guess - 1;
				else
					correct = true;
			}
			Console.WriteLine("Looks like I found the correct number!");
			Console.Write("Press a key to exit...");
			Console.ReadKey();
		}
	}
}
