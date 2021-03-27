using System;
using System.Collections.Generic;

namespace InterviewPreparation.Exercises
{
    class LongestSubstringWORepeated
    {
        public int LengthOfLongestSubstring(string s)
        {
            var max = 0;

            for (int i = 0; i < s.Length; i++)
            {
                var visitedChars = new HashSet<char>();
                var foundRepeated = false;
                var actualCount = 0;

                for (int j = i; j < s.Length && !foundRepeated; j++)
                {
                    if (!visitedChars.Contains(s[j]))
                    {
                        visitedChars.Add(s[j]);
                        actualCount++;
                        max = Math.Max(max, actualCount);
                    }
                    else
                    {
                        foundRepeated = true;
                    }
                }
            }

            return max;
        }

        public int OptimizedLengthOfLongestSubstring(string s)
        {
            var positions = new Dictionary<char, int>();
            var max = 0;
            var i = 0;

            for (int j = 0; j < s.Length; j++)
            {
                var alreadyVisitedChar = positions.ContainsKey(s[j]);

                if (alreadyVisitedChar)
                {
                    i = Math.Max(positions[s[j]], i);
                }

                max = Math.Max(max, j - i + 1);

                if (alreadyVisitedChar)
                {
                    positions[s[j]] = j + 1;
                }
                else
                {
                    positions.Add(s[j], j + 1);
                }
            }

            return max;
        }
    }
}

