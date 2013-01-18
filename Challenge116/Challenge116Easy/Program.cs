/*
 * Challenge 116 [Easy] (Permutation of a string)
 * http://www.reddit.com/r/dailyprogrammer/comments/164zvs/010713_challenge_116_easy_permutation_of_a_string/
 */

using System;
using System.Collections.Generic;

namespace Challenge116Easy
{
	public class Program
	{
		public static void Main(string[] args)
		{
			foreach (var perm in GetPermutations("daily"))
				Console.WriteLine(perm);
			Console.ReadKey();
		}

		private static IEnumerable<string> GetPermutations(string str)
		{
			if (str.Length <= 1) // If there's only one letter there are no permutations
				return new HashSet<string> {str};

			// Store the permutations in a hashset (ensures no duplicates)
			var set = new HashSet<string>();

			// Iterate over all the characters in the input string
			foreach (var c in str)
			{
				// Get the other characters in the string (remove first occurrence of c)
				var others = str.Remove(str.IndexOf(c), 1);
				// Get permutation(s) of this new string...
				var sub = GetPermutations(others);
				// ... and add them to our hashset
				foreach (var substr in sub)
					set.Add(c + substr);
			}

			return set;
		}
	}
}
