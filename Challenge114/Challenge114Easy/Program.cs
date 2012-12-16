using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Challenge114Easy
{
	public class Program
	{
		private const string DefaultFile = "words.txt";

		private static string[] _list;

		private static readonly Func<string, string[], string[]> Matcher =
			(needle, list) =>
				(from item in list
					where item.Where(
						(c, i) => c != needle[i]
					).Count() == 1
					select item
				).ToArray();

		static void Main(string[] args)
		{
			var file = args.Length > 0
				           ? args[0]
				           : (File.Exists(DefaultFile)
					              ? DefaultFile
					              : Utilities.Input.GetInput("Unable to locate source file, please specify manually:",
					                                         "Invalid file! Please specify a valid file:", File.Exists));

			if (!File.Exists(file))
			{
				Console.WriteLine("Unable to find word list file: {0}", file);
				Environment.Exit(1);
			}

			var start = DateTime.Now;

			_list = File.ReadAllLines(file);

			// hardcoded because reasons
			Matcher("best", _list).ToList().ForEach(Console.WriteLine);

			var bonus1 = (from li in _list where (Matcher(li, _list).Count() == 33) select li).First();
			Console.WriteLine("Bonus 1: {0}", bonus1);

			var bonus2 = PossibleWords("best").ToList();
			Console.WriteLine("Bonus 2: {0}", bonus2.Count());

			var end = DateTime.Now;
			Console.WriteLine("{0} milliseconds", (end - start).TotalMilliseconds);

			Console.ReadLine();
		}

		private static IEnumerable<string> PossibleWords(string word, int level = 1)
		{
			var words = new HashSet<string>();
			Matcher(word, _list).ToList().ForEach(w => words.Add(w));

			if (level < 3)
			{
				var toAdd = new List<string>();
				foreach (var item in words)
					toAdd.AddRange(PossibleWords(item, level + 1));

				toAdd.ForEach(w => words.Add(w));
			}

			return words.Distinct();
		}
	}
}
