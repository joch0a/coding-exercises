using System.Collections.Generic;
using System.Text;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class LetterCombination
    {
        public Dictionary<char, string> dict = new Dictionary<char, string>()
    {
        {'2', "abc"},
        {'3', "def"},
        {'4', "ghi"},
        {'5', "jkl"},
        {'6', "mno"},
        {'7', "pqrs"},
        {'8', "tuv"},
        {'9', "wxyz"}
    };

        public IList<string> LetterCombinations(string digits)
        {
            if (digits == "")
            {
                return new List<string>();
            }
            var result = new List<string>();

            Backtrack(digits, 0, new StringBuilder(), result);

            return result;
        }

        public void Backtrack(string digits, int index, StringBuilder sb, IList<string> list)
        {
            if (index == digits.Length)
            {
                list.Add(sb.ToString());

                return;
            }

            foreach (var c in dict[digits[index]])
            {
                sb.Append(c);

                Backtrack(digits, index + 1, sb, list);

                sb.Remove(sb.Length - 1, 1);
            }
        }
    }

    public class Revision
    {
        public string[] pad = new string[]
        {
            "",
            "",
            "abc",
            "def",
            "ghi",
            "jkl",
            "mno",
            "pqrs",
            "tuv",
            "wxyz"
        };

        public IList<string> LetterCombinations(string digits)
        {
            var combinations = new List<string>();

            if (digits.Length < 1)
            {
                return combinations;
            }

            Backtrack(digits, 0, new StringBuilder(), combinations);

            return combinations;
        }

        private void Backtrack(string digits, int index, StringBuilder current, IList<string> combinations)
        {
            if (index == digits.Length)
            {
                combinations.Add(current.ToString());

                return;
            }

            var currentNumber = (int)digits[index] - '0';

            foreach (var ch in pad[currentNumber])
            {
                current.Append(ch);

                Backtrack(digits, index + 1, current, combinations);

                current.Length -= 1;
            }
        }
    }
}
