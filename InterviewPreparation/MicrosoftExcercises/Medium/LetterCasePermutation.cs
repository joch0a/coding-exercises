using System.Collections.Generic;
using System.Text;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class LetterCasePermutation
    {
        public IList<string> Solve(string S)
        {
            var permutations = new List<string>();

            Backtrack(S, new StringBuilder(), permutations);

            return permutations;
        }

        private void Backtrack(string str, StringBuilder permutation, IList<string> permutations)
        {
            if (permutation.Length == str.Length)
            {
                permutations.Add(permutation.ToString());

                return;
            }

            var validChars = CalculateValidPermutations(str, permutation.Length);

            foreach (var validChar in validChars)
            {
                permutation.Append(validChar);

                Backtrack(str, permutation, permutations);

                permutation.Remove(permutation.Length - 1, 1);
            }
        }

        private IList<char> CalculateValidPermutations(string str, int index)
        {
            var validChars = new List<char>();
            var actualLetter = str[index];

            if (char.IsLetter(actualLetter))
            {
                validChars.Add(char.ToUpper(actualLetter));
                validChars.Add(char.ToLower(actualLetter));
            }
            else
            {
                validChars.Add(actualLetter);
            }

            return validChars;
        }
    }
}
