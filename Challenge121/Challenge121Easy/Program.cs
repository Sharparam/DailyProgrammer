/*
 * Challenge #121 [easy] (Bytelandian Exchange 1)
 * http://www.reddit.com/r/dailyprogrammer/comments/19mn2d/030413_challenge_121_easy_bytelandian_exchange_1/
 */

using System;
using System.Collections.Generic;

namespace Challenge121Easy
{
	public static class Program
	{
		private static Dictionary<int, int> _values; 

		public static void Main()
		{
			_values = new Dictionary<int, int> {{0, 1}};

			bool success;
			do
			{
				Console.Write("Choose a coin: ");
				var input = Console.ReadLine();
				int coin;
				success = int.TryParse(input, out coin);
				if (success && coin > 0)
					Console.WriteLine("You get " + Exchange(coin) + " 0-coins");

			} while (success);
		}

		private static int Exchange(int n)
		{
			return _values.ContainsKey(n) ? _values[n] : Exchange(n / 2) + Exchange(n / 3) + Exchange(n / 4);
		}
	}
}
