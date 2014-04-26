/*
 * Challenge #20 [Easy] (Prime numbers below 2000)
 * http://www.reddit.com/r/dailyprogrammer/comments/qnkro/382012_challenge_20_easy/
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Challenge20Easy
{
    public class Program
    {
        private const int Limit = Int32.MaxValue;

        private static readonly Dictionary<int, bool> Numbers = new Dictionary<int, bool>
        {
            {1, true},
            {2, true}
        };

        public static void Main(string[] args)
        {
            bool run = true;
            while (run)
            {
                Console.Write("> ");
                var input = Console.ReadLine();
                if (input.ToLower()[0] == 'q')
                    run = false;
                else
                    Calculate(int.Parse(input));
            }
            Console.ReadLine();
        }

        private static void Calculate(int limit)
        {
            var timer = new Stopwatch();
            timer.Start();
            var primes = new List<int>();
            for (var n = limit; n > 0; n--)
                if (IsPrime(n))
                    primes.Add(n);
            //primes.Sort();
            timer.Stop();
            //Console.WriteLine(String.Join(", ", primes));
            Console.WriteLine("Calculated in {0}ms", timer.ElapsedMilliseconds);
        }

        private static bool IsPrime(int num)
        {
            if (Numbers.ContainsKey(num))
                return Numbers[num];

            if (num % 2 == 0)
            {
                Numbers[num] = false;
                return false;
            }

            var limit = (int) Math.Floor(Math.Sqrt(num));

            for (var i = 3; i <= limit; i++)
            {
                if (num != i && num % i == 0)
                {
                    Numbers[num] = false;
                    return false;
                }
            }

            Numbers[num] = true;
            return true;
        }
    }
}
