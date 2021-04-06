using System;
using System.Collections.Generic;

namespace InterviewPreparation.TrainExercises.Easy
{
    class LargestSubstringBetweenTwoEqualCharacters
    {
        public int MaxLengthBetweenEqualCharacters(string s)
        {
            var max = -1;

            var dictionaryFirstPosition = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (dictionaryFirstPosition.ContainsKey(s[i]))
                {
                    max = Math.Max(max, i - dictionaryFirstPosition[s[i]] - 1);
                }
                else
                {
                    dictionaryFirstPosition.Add(s[i], i);
                }
            }

            return max;
        }
    }
}
