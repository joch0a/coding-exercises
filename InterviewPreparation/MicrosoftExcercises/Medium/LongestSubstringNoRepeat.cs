using System;
using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class LongestSubstringNoRepeat
    {
        public int LengthOfLongestSubstring(string s)
        {
            var positions = new Dictionary<char, int>();
            var longest = 0;
            var i = 0;
            for (int j = 0; j < s.Length; j++)
            {
                var visited = positions.ContainsKey(s[j]);

                if (visited)
                {
                    i = Math.Max(i, positions[s[j]]);
                }

                longest = Math.Max(longest, j - i + 1);

                if (visited)
                {
                    positions[s[j]] = j + 1;
                }
                else
                {
                    positions.Add(s[j], j + 1);
                }
            }

            return longest;
        }
    }
}
