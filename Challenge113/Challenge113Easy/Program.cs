/*
 * Challenge #113 [Easy] (String-type checking)
 * http://www.reddit.com/r/dailyprogrammer/comments/13hmz3/11202012_challenge_113_easy_stringtype_checking/
 */

using System;
using System.Text.RegularExpressions;

namespace Challenge113Easy
{
	public class Program
	{
		private static readonly Regex IntRegex = new Regex(@"^[+-]?\d+$", RegexOptions.Compiled);
		private static readonly Regex FloatRegex = new Regex(@"^[+-]?\d+[\.,]\d+$", RegexOptions.Compiled);
		private static readonly Regex DateRegex = new Regex(@"^\d{1,2}-\d{1,2}-(?:\d{2}|\d{4})$", RegexOptions.Compiled);

		static void Main()
		{
			var quit = false;
			while (!quit)
			{
				var input = Utilities.Input.GetInput("Write something ('quit' to quit):", "Write something ('quit' to quit):", s => !string.IsNullOrEmpty(s));
				if (input == "quit")
					quit = true;
				else if (IntRegex.IsMatch(input))
					Console.WriteLine("int");
				else if (FloatRegex.IsMatch(input))
					Console.WriteLine("float");
				else if (DateRegex.IsMatch(input))
					Console.WriteLine("date");
				else
					Console.WriteLine("string");
			}
		}
	}
}
