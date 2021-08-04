using System;
using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Hard
{
    class MinWindowSubstring
    {
        //FIRST APPROACH (MINE)
        public string MinWindow(string str, string t)
        {
            var minLeft = -1;
            var minRight = -1;
            var frequencyStr = CreateFrequencyDictionary(str);
            var frequencyT = CreateFrequencyDictionary(t);
            var currentFrequency = new Dictionary<char, int>();
            var left = 0;
            var right = 0;

            if (!ContainsAllLetter(frequencyT, frequencyStr))
            {
                return "";
            }

            while (left < str.Length && right < str.Length)
            {
                while (!ContainsAllLetter(frequencyT, currentFrequency) && right < str.Length)
                {
                    if (!currentFrequency.ContainsKey(str[right]))
                    {
                        currentFrequency.Add(str[right], 0);
                    }

                    currentFrequency[str[right]]++;

                    right++;
                }

                while (ContainsAllLetter(frequencyT, currentFrequency) && left < str.Length)
                {
                    if (right - left < minRight - minLeft || minLeft == -1)
                    {
                        minLeft = left;
                        minRight = right;
                    }

                    currentFrequency[str[left]]--;
                    left++;
                }
            }

            if (minLeft == -1)
            {
                return string.Empty;
            }

            return str.Substring(minLeft, minRight - minLeft);
        }

        private bool ContainsAllLetter(Dictionary<char, int> freqT, Dictionary<char, int> freqCurrent)
        {
            foreach (var key in freqT.Keys)
            {
                if (!freqCurrent.ContainsKey(key) || freqT[key] > freqCurrent[key])
                {
                    return false;
                }
            }
            return true;
        }

        private Dictionary<char, int> CreateFrequencyDictionary(string str)
        {
            var dict = new Dictionary<char, int>();

            foreach (var c in str)
            {
                if (!dict.ContainsKey(c))
                {
                    dict.Add(c, 0);
                }

                dict[c]++;
            }

            return dict;
        }

        //optimized

        public string MinWindowOPTIMIZED(string str, string t)
        {
            var count = t.Length;
            var result = string.Empty;
            var freq = new int[128];
            var left = 0;
            var right = 0;

            foreach (var c in t)
            {
                freq[c]++;
            }

            while (right < str.Length)
            {
                if (freq[str[right]] > 0)
                {
                    count--;
                }

                freq[str[right]]--;
                right++;

                while (count == 0)
                {
                    if (string.IsNullOrEmpty(result) || right - left < result.Length)
                    {
                        result = str.Substring(left, right - left);
                    }

                    if (freq[str[left]] == 0)
                    {
                        count++;
                    }

                    freq[str[left]]++;
                    left++;
                }
            }

            return result;
        }
    }
}
