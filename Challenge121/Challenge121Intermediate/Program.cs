/*
 * Challenge #121 [intermediate] (Bytelandian Exchange 2)
 * http://www.reddit.com/r/dailyprogrammer/comments/19rkqr/030613_challenge_121_intermediate_bytelandian/
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Challenge121Intermediate
{
	public static class Program
	{
		private const string OutputFormat = "{0} 0-coins with a {1} profit (Total: {2})";

		private static Dictionary<ulong, CoinData> _data;

		private struct CoinData
		{
			public ulong Value;
			public ulong ExchangeCount; // Number of 0-coins this coin gives
			public ulong Profit; // Profit gained from exchange of this coin

			public static CoinData operator +(CoinData left, CoinData right)
			{
				return new CoinData
				{
					Value = left.Value, // Doing this might be confusing, but whatever
					ExchangeCount = left.ExchangeCount + right.ExchangeCount,
					Profit = left.Profit + right.Profit
				};
			}

			public override string ToString()
			{
				return string.Format(OutputFormat, ExchangeCount, Profit, Value + Profit);
			}
		}

		public static void Main()
		{
			_data = new Dictionary<ulong, CoinData> {{0, new CoinData {ExchangeCount = 1, Profit = 0}}};

			bool success;
			do
			{
				Console.Write("Choose a coin: ");
				var input = (Console.ReadLine() ?? "10000000000").Replace(",",""); // This way the user can input "1,000,000" and it will turn into "1000000"
				ulong coin;
				success = ulong.TryParse(input, out coin);

				if (!success || coin <= 0)
					continue;

				var watch = new Stopwatch();
				watch.Start();
				var data = Exchange(coin);
				var elapsed = watch.ElapsedMilliseconds;
				Console.WriteLine("Result: " + data);
				Console.WriteLine("Calculation finished in " + elapsed + " milliseconds");
			} while (success);
		}

		private static CoinData Exchange(ulong n)
		{
			if (_data.ContainsKey(n))
				return _data[n];

			var coin1 = n / 2;
			var coin2 = n / 3;
			var coin3 = n / 4;
			var coinTotal = coin1 + coin2 + coin3;

			var profit = (n > coinTotal) ? 0 : (coinTotal - n);

			var data = new CoinData
			{
				Value = n,
				Profit = profit
			};

			var result = data + Exchange(coin1) + Exchange(coin2) + Exchange(coin3);
			_data[n] = result;
			return result;
		}
	}
}
