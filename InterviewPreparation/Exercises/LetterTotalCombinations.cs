using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewPreparation.Exercises
{
    class LetterTotalCombinations
    {
        public IList<string> LetterCombinations(string digits)
        {
            var dictionary = new Dictionary<char, char[]>();
            var combinations = new List<string>();

            if (digits == null || digits.Length == 0)
            {
                return combinations;
            }

            dictionary.Add('2', new char[] { 'a', 'b', 'c' });
            dictionary.Add('3', new char[] { 'd', 'e', 'f' });
            dictionary.Add('4', new char[] { 'g', 'h', 'i' });
            dictionary.Add('5', new char[] { 'j', 'k', 'l' });
            dictionary.Add('6', new char[] { 'm', 'n', 'o' });
            dictionary.Add('7', new char[] { 'p', 'q', 'r', 's' });
            dictionary.Add('8', new char[] { 't', 'u', 'v' });
            dictionary.Add('9', new char[] { 'w', 'x', 'y', 'z' });

            Backtrack(0, new StringBuilder(), combinations, dictionary, digits);

            return combinations;
        }

        private void Backtrack(int index,
                               StringBuilder path,
                               IList<string> combinations,
                               Dictionary<char, char[]> dictionary,
                               string digits)
        {
            if (path.Length == digits.Length)
            {
                combinations.Add(path.ToString());
                return;
            }

            var letterCombinations = dictionary[digits[index]];

            foreach (var letter in letterCombinations)
            {
                path.Append(letter);

                Backtrack(index + 1, path, combinations, dictionary, digits);

                path.Remove(path.Length - 1, 1);
            }
        }
    }
}
}
