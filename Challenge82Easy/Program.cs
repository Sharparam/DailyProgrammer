using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Challenge82Easy
{
	public class Program
	{
		private static char[] _letters;

		public static void Main(string[] args)
		{
			DateTime start;

			Console.WriteLine("Build your own set of letters? (t for theoretical calculation)");
			var choice = Console.ReadLine();
			char mode = string.IsNullOrEmpty(choice) ? 'N' : choice.ToUpper()[0];
			if (mode == 'Y') // Bonus 2
			{
				var input = Utilities.Input.GetInput("Please write your letters:", "Invalid input, please write your letters:", s => !string.IsNullOrEmpty(s));
				start = DateTime.Now;
				_letters = input.ToArray();
			}
			else if (mode == 'T') // Bonus 1
			{
				// This is not a very efficient way to get number
				var input = Utilities.Input.GetInput("How many letters?", "Invalid number, please input a valid number:", s =>
				{
					double r;
					var b = double.TryParse(s, out r);
					return b;
				});
				var count = double.Parse(input);
				
				// The amount of possible substrings can be calculated with the formula:
				// n = (c + 1) * (c / 2)
				// Where 'n' is the resulting number of substrings and 'c' is number of letters
				var possible = (count + 1) * (count / 2.0);

				Console.WriteLine("The amount of possible substrings with a {0}-letter alphabet (where all letters are assumed to be unique) is {1}", count, possible);
				Console.ReadLine();
				return;
			}
			else // Normal
			{
				int count = 5;

				start = DateTime.Now;

				// Build the needed letters
				_letters = new char[count];
				char current = 'a';
				for (int i = 0; i < count; i++)
					_letters[i] = current++;
			}

			var subs = GetSubstrings();

			var generateEnd = DateTime.Now;

			foreach (var sub in subs)
			{
				Console.WriteLine(sub);
			}

			Console.WriteLine("{0} substrings from {1} letters", subs.Count(), _letters.Length);

			var end = DateTime.Now;

			Console.WriteLine("Time to generate: {0} milliseconds", (generateEnd - start).TotalMilliseconds);
			Console.WriteLine("Time to print: {0} milliseconds", (end - generateEnd).TotalMilliseconds);
			Console.WriteLine("Total time: {0} milliseconds", (end - start).TotalMilliseconds);

			Console.ReadLine();
		}

		private static IEnumerable<string> GetSubstrings(int offset = 0)
		{
			var result = new List<string>();

			if (offset == _letters.Length - 1)
				result.Add(_letters[offset].ToString());
			else
			{
				for (int i = offset; i < _letters.Length; i++)
				{
					var sb = new StringBuilder(); // Using StringBuilder doesn't seem to give much of a speed advantage here
					for (int n = offset; n <= i; n++)
						sb.Append(_letters[n]);

					result.Add(sb.ToString());
				}

				result.AddRange(GetSubstrings(offset + 1));
			}

			return result.Distinct();
		}
	}
}
