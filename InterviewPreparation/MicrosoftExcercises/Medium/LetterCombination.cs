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
}
