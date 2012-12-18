/*
 * [difficult] Challenge #1
 * http://www.reddit.com/r/dailyprogrammer/comments/pii6j/difficult_challenge_1/
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge1Difficult
{
	class Program
	{
		private static readonly Random Rand = new Random(DateTime.Now.Millisecond);
		private static int _number;
		private static readonly List<Try> Tries = new List<Try>();
		private const uint NumTests = (uint)1E+8;
		private const int UpperLimit = 100;

		public static void Main(string[] args)
		{

			Console.WriteLine("Completing {0} tests between 1-{1}", NumTests, UpperLimit);
			uint runs = 0;
			var start = DateTime.Now;
			while (runs < NumTests)
			{
				try
				{
					Run(false);
					runs++;
				}
				catch (OutOfMemoryException ex)
				{
					Console.WriteLine("Ran out of memory after {0} runs! Returning results gathered so far...", runs + 1);
					break;
				}
				
			}
			var end = DateTime.Now;
			Console.WriteLine("Did {0} runs in {1} milliseconds! Result:", runs + 1, (end - start).TotalMilliseconds);
			int totalGuesses = 0;
			int totalTries = Tries.Count;
			for (int i = 0; i < totalTries; i++)
			{
				//Console.WriteLine("{0,5}: Guessed number {1,3} in {2,3} tries.", i + 1, _tries[i].Number, _tries[i].Guesses);
				totalGuesses += Tries[i].Guesses;
			}
			Console.WriteLine("Average number of guesses needed: {0,5}", (double) totalGuesses / totalTries);
			Console.ReadKey();
		}

		private static void Run(bool human)
		{
			// Only print status messages if human

			if (human)
			{
				var input = Utilities.Input.GetInput("Enter a number (1-" + UpperLimit + "):",
				                                     "Invalid number, please enter a number between 1 and " + UpperLimit + ":", s =>
				                                     {
					                                     int r;
					                                     var b = int.TryParse(s, out r);
					                                     return b;
				                                     });
				_number = int.Parse(input);
			}
			else
				_number = Rand.Next(1, UpperLimit + 1);
			
			if (human)
				Console.WriteLine("You have chosen the number {0}, I will now try to guess it. Please tell me \"too low\", \"too high\" or \"correct\".", _number);
			bool correct = false;
			int upper = UpperLimit + 1;
			int lower = 1;
			int guesses = 0;
			while (!correct)
			{
				int guess = Rand.Next(lower, upper);
				guesses++;
				char response;
				if (human)
				{
					Console.WriteLine("Is it {0}?", guess);
					response = Utilities.Input.GetInput("\"too low\", \"too high\" or \"correct\":",
					                                    "\"too low\", \"too high\" or \"correct\":",
					                                    s =>
					                                    {
						                                    if (string.IsNullOrEmpty(s))
							                                    return false;
						                                    char c = s.Split(' ').Last().ToLower()[0];
						                                    if (c != 'l' && c != 'h' && c != 'c' && c != 'y')
							                                    return false;
						                                    return true;
					                                    }).ToLower().Split(' ').Last()[0];
				}
				else
					response = guess < _number ? 'l' : (guess > _number ? 'h' : 'c');

				if (response == 'l')
					lower = guess + 1;
				else if (response == 'h')
					upper = guess - 1;
				else
					correct = true;
			}
			if (human)
			{
				Console.WriteLine("The number you chose was {0} and I found it in {1} guesses!", _number, guesses);
				Console.Write("Press a key to exit...");
				Console.ReadKey();
			}
			Tries.Add(new Try {Number = _number, Guesses = guesses});
		}
	}
}
