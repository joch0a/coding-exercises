using System.Collections.Generic;
using System.Text;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class RemoveDuplicatesStringLexo
    {
        public string RemoveDuplicateLetters(string str)
        {
            var counts = new int[26];
            var sb = new StringBuilder();
            var visited = new HashSet<char>();

            foreach (var currentChar in str)
            {
                counts[currentChar - 'a']++;
            }

            for (var currentIndex = 0; currentIndex < str.Length; currentIndex++)
            {
                var currentChar = str[currentIndex];
                counts[currentChar - 'a']--;

                if (visited.Contains(currentChar))
                {
                    continue;
                }

                while (sb.Length > 0 &&
                      sb[sb.Length - 1] > currentChar &&
                      counts[sb[sb.Length - 1] - 'a'] > 0)
                {
                    visited.Remove(sb[sb.Length - 1]);
                    sb.Length--;
                }

                sb.Append(currentChar);
                visited.Add(currentChar);
            }

            return sb.ToString();
        }
    }
}
