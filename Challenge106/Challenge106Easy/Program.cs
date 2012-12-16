/*
 * Challenge #106 [Easy] (Random Talker, Part 1)
 * http://www.reddit.com/r/dailyprogrammer/comments/11xje0/10232012_challenge_106_easy_random_talker_part_1/
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Challenge106Easy
{
	public class Program
	{
		private const string LongTextFile = "metamorphosis.txt";
		private static readonly Regex WordRegex = new Regex(@"\w+|[""\.,:;!?()[\]{}]", RegexOptions.Compiled);
		private static readonly Dictionary<string, int> Words = new Dictionary<string, int>(); 

		public static void Main(string[] args)
		{
			var file = args.Length > 0
				           ? args[0]
				           : (File.Exists(LongTextFile)
					              ? LongTextFile
					              : Utilities.Input.GetInput("Unable to locate source file, please specify manually:",
					                                         "Invalid file! Please specify a valid file:", File.Exists));

			if (!File.Exists(file))
			{
				Console.WriteLine("Unable to locate file {0}", file);
				Environment.Exit(1);
			}

			var start = DateTime.Now;

			foreach (var line in File.ReadAllLines(file))
			{
				var matches = WordRegex.Matches(line);
				foreach (var match in matches)
				{
					var word = match.ToString().ToLower();
					if (Words.ContainsKey(word))
						Words[word] = Words[word] + 1;
					else
						Words.Add(word, 1);
				}
			}

			List<KeyValuePair<string, int>> sorted = Words.ToList();

			sorted.Sort((first, second) => second.Value.CompareTo(first.Value));

			Console.WriteLine("The top 10 words and punctuations:");
			for (var i = 0; i < 10; i++)
				Console.WriteLine(" {0,2}  :  {1,-5}:{2,5}", i + 1, sorted[i].Key, sorted[i].Value);

			var end = DateTime.Now;
			Console.WriteLine("{0} milliseconds", (end - start).TotalMilliseconds);
			Console.ReadLine();
		}
	}
}
