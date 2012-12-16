using System;

namespace Utilities
{
	public class Input
	{
		public static string GetInput(string message, string error, Func<string, bool> validator)
		{
			Console.WriteLine(message);
			var input = string.Empty;
			var valid = false;
			while (!valid)
			{
				input = Console.ReadLine();
				valid = validator(input);
				if (!valid)
					Console.WriteLine(error);
			}
			
			return input;
		}
	}
}
