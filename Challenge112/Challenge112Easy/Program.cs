using System;
using System.Text.RegularExpressions;

namespace Challenge112Easy
{
	class Program
	{
		// Original URL regex by itsbth, modified to fit the assignment
		private static readonly Regex UrlRegex = new Regex(@"^https?://[a-z0-9\-]+(?:\.[a-z0-9\-]+)*(?::[0-9]+)?/(?:[^\?][\w\-_\.~!*'();:@&=+$,/?%#[\]]*?)?(?:\?([\w\-_\.~!*'();:@&=+$,/?%#[\]]+))?$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
		private static readonly Regex ArgsRegex = new Regex(@"&?(\w+)=(\w+)&?", RegexOptions.Compiled);

		static void Main()
		{
			var quit = false;
			while (!quit)
			{
				var input = Utilities.Input.GetInput("Input a valid URL or 'quit':", "Not a valid URL or 'quit':", s => !string.IsNullOrEmpty(s) && (s.ToLower() == "quit" || UrlRegex.IsMatch(s)));
				if (input == "quit")
					quit = true;
				else // input contains a valid URL
				{
					var urlMatch = UrlRegex.Match(input);
					if (urlMatch.Groups.Count < 2)
						Console.WriteLine("No args found in URL");
					else
					{
						var argString = urlMatch.Groups[1].ToString();
						if (ArgsRegex.IsMatch(argString))
							foreach (Match match in ArgsRegex.Matches(argString))
								Console.WriteLine("{0} = {1}", match.Groups[1], match.Groups[2]);
						else
							Console.WriteLine("Not a valid argument string");
					}
				}
			}
		}
	}
}
