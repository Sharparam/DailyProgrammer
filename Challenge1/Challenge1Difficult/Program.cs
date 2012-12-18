/*
 * [difficult] Challenge #1
 * http://www.reddit.com/r/dailyprogrammer/comments/pii6j/difficult_challenge_1/
 */

using System;
using System.Linq;

namespace Challenge1Difficult
{
	class Program
	{
		private static readonly Random Rand = new Random(DateTime.Now.Millisecond);
		private static int _number;
		private const uint NumTests = (uint)1E+8;
		private const int UpperLimit = 100;

		private static double _totalGuessCount;

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
				catch (OutOfMemoryException)
				{
					Console.WriteLine("Ran out of memory after {0} runs! Returning results gathered so far...", runs);
					break;
				}
			}
			var end = DateTime.Now;
			Console.WriteLine("Did {0} runs in {1} milliseconds! Result:", runs, (end - start).TotalMilliseconds);
			Console.WriteLine("Average number of guesses needed: {0,5}", _totalGuessCount / runs);
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
			var correct = false;
			var upper = UpperLimit + 1;
			var lower = 1;
			var guesses = 0;
			while (!correct)
			{
				var guess = Rand.Next(lower, upper);
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
						                                    var c = s.Split(' ').Last().ToLower()[0];
						                                    return c == 'l' || c == 'h' || c == 'c' || c == 'y';
					                                    }).ToLower().Split(' ').Last()[0];
				}
				else
					response = guess < _number ? 'l' : (guess > _number ? 'h' : 'c');

				switch (response)
				{
					case 'l':
						lower = guess + 1;
						break;
					case 'h':
						upper = guess - 1;
						break;
					default:
						correct = true;
						break;
				}
			}

			_totalGuessCount += guesses;

			if (!human)
				return;

			Console.WriteLine("The number you chose was {0} and I found it in {1} guesses!", _number, guesses);
			Console.Write("Press a key to exit...");
			Console.ReadKey();
		}
	}
}
