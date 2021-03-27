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
    }
}
