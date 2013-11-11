/*
 * Challenge #14 [Intermediate] (Sieve of Sundaram)
 * http://www.reddit.com/r/dailyprogrammer/comments/q2mwu/2232012_challenge_14_intermediate/
 */

using System.Collections.Generic;
using System.Linq;

namespace Challenge14Intermediate
{
    public class Program
    {
        private const int DefaultLimit = 10000;

        public static void Main(string[] args)
        {
            var limit = args.Length > 0 ? int.Parse(args[0]) : DefaultLimit;
            var list = new HashSet<int>();
            for (var n = 1; n <= limit; n++)
            {
                
            }
        }

        private static bool IsValid(int i, int j, int n)
        {
            return i + j + 2*i*j > n;
        }
    }
}
