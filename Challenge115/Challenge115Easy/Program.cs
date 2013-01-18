/*
 * Challenge #115 [easy] (Guess-that-number game)
 * http://www.reddit.com/r/dailyprogrammer/comments/15ul7q/122013_challenge_115_easy_guessthatnumber_game/
 */

using System;

namespace Challenge115Easy
{
	class Program
	{
		static void Main()
		{
			var number = new Random().Next(1, 101);
			var guess = 0;
			while (guess != number)
			{
				Console.WriteLine("Guess a number between 1 and 100!");
				var input = Console.ReadLine();
				var success = int.TryParse(input, out guess);
				if (!success || guess < 1 || guess > 100)
					Console.WriteLine("Invalid number!");
				else if (guess < number)
					Console.WriteLine("Too low!");
				else if (guess > number)
					Console.WriteLine("Too high!");
				else
					Console.WriteLine("Correct!");
			}
			Console.Write("Press a key to exit...");
			Console.ReadKey(true);
		}
	}
}
