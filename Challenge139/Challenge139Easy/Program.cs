/*
 * Challenge #139 [Easy] (Pangrams)
 * http://www.reddit.com/r/dailyprogrammer/comments/1pwl73/11413_challenge_139_easy_pangrams/
 */

using System;
using System.Linq;

namespace Challenge139Easy
{
    public class Program
    {
        private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";

        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var num = int.Parse(input);
            var lines = new string[num];
            for (var i = 0; i < num; i++)
                lines[i] = Console.ReadLine().ToLower();

            foreach (var line in lines)
            {
                Console.Write(Alphabet.All(c => line.Contains(c)) ? "True: " : "False: ");

                Console.WriteLine(String.Join(", ", Alphabet.Select(l => String.Format("{0}: {1}", l, line.Count(c => c == l)))));
            }

            Console.ReadLine();
        }
    }
}
