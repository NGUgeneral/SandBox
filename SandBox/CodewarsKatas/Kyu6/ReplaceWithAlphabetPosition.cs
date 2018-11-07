using System.Collections.Generic;
using System.Text;

namespace SandBox.CodewarsKatas.Kyu6
{
    //https://www.codewars.com/kata/replace-with-alphabet-position/train/csharp
    public static class ReplaceWithAlphabetPosition
    {
        public static string AlphabetPosition(string text)
        {
            var result = new StringBuilder();
            foreach (var c in text.ToLower())
            {
                if (Alphabet.TryGetValue(c, out var num))
                    result.Append(num + " ");
            }
            result.Remove(result.Length - 1, 1);

            return result.ToString();
        }

        private static Dictionary<char, int> Alphabet = new Dictionary<char, int>()
        {
            {'a', 1 },
            {'b', 2 },
            {'c', 3 },
            {'d', 4 },
            {'e', 5 },
            {'f', 6 },
            {'g', 7 },
            {'h', 8 },
            {'i', 9 },
            {'j', 10 },
            {'k', 11 },
            {'l', 12 },
            {'m', 13 },
            {'n', 14 },
            {'o', 15 },
            {'p', 16 },
            {'q', 17 },
            {'r', 18 },
            {'s', 19 },
            {'t', 20 },
            {'u', 21 },
            {'v', 22 },
            {'w', 23 },
            {'x', 24 },
            {'y', 25 },
            {'z', 26 }
        };
    }
}
