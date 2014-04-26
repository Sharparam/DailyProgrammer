using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Challenge156Hard
{
    public static class Program
    {
        private static readonly Dictionary<char, char> CharacterMap = new Dictionary<char, char>
        {
            {'A', '∀'}, {'B', 'q'}, {'C', 'Ɔ'}, {'D', 'p'}, {'E', 'Ǝ'}, {'F', 'Ⅎ'}, {'G', 'פ'}, {'H', 'H'}, {'I', 'I'}, {'J', 'ſ'}, {'K', 'ʞ'}, {'L', '˥'}, {'M', 'W'}, {'N', 'N'},
            {'O', 'O'}, {'P', 'Ԁ'}, {'Q', 'Q'}, {'R', 'ɹ'}, {'S', 'S'}, {'T', '┴'}, {'U', '∩'}, {'V', 'Λ'}, {'W', 'M'}, {'X', 'X'}, {'Y', '⅄'}, {'Z', 'Z'}, {'a', 'ɐ'}, {'b', 'q'},
            {'c', 'ɔ'}, {'d', 'p'}, {'e', 'ǝ'}, {'f', 'ɟ'}, {'g', 'ƃ'}, {'h', 'ɥ'}, {'i', 'ᴉ'}, {'j', 'ɾ'}, {'k', 'ʞ'}, {'l', 'l'}, {'m', 'ɯ'}, {'n', 'u'}, {'o', 'o'}, {'p', 'd'},
            {'q', 'b'}, {'r', 'ɹ'}, {'s', 's'}, {'t', 'ʇ'}, {'u', 'n'}, {'v', 'ʌ'}, {'w', 'ʍ'}, {'x', 'x'}, {'y', 'ʎ'}, {'z', 'z'}, {'0', '0'}, {'1', 'Ɩ'}, {'2', 'ᄅ'}, {'3', 'Ɛ'},
            {'4', 'ㄣ'}, {'5', 'ϛ'}, {'6', '9'}, {'7', 'ㄥ'}, {'8', '8'}, {'9', '6'}, {'.', '˙'}, {'?', '¿'}, {'!', '¡'}
        };

        public static void Main(string[] args)
        {
            File.Delete("output.txt");
            var lines = new List<string>();
            if (File.Exists("input.txt"))
                lines = File.ReadAllLines("input.txt").ToList();
            else
            {
                string line;
                while (!string.IsNullOrEmpty(line = Console.ReadLine()))
                    lines.Add(line);
            }
            lines.Reverse();
            lines.ForEach(ProcessLine);
            Console.ReadLine();
        }

        private static char Transform(char source)
        {
            return CharacterMap.ContainsKey(source) ? CharacterMap[source] : source;
        }

        private static string Transform(string source)
        {
            var result = new StringBuilder();
            for (var i = source.Length - 1; i >= 0; i--)
                result.Append(Transform(source[i]));
            return result.ToString();
        }

        private static void ProcessLine(string line)
        {
            line = Transform(line);
            Console.WriteLine(line);
            File.AppendAllText("output.txt", String.Format("{0}\r\n", line));
        }
    }
}
