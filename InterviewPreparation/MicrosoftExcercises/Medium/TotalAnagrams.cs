using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class TotalAnagrams
    {
        public IList<int> FindAnagrams(string s, string p)
        {
            if (p.Length > s.Length)
            {
                return new List<int>();
            }

            var freq = BuildFrequency(p);
            var count = p.Length;
            var totalAnagrams = new List<int>();
            var window = p.Length;

            for (int i = 0; i < s.Length; i++)
            {
                if (freq[s[i] - 'a'] > 0)
                {
                    count--;
                }

                freq[s[i] - 'a']--;

                if (i >= window)
                {
                    freq[s[i - window] - 'a']++;

                    if (freq[s[i - window] - 'a'] > 0)
                    {
                        count++;
                    }
                }

                if (count == 0)
                {
                    totalAnagrams.Add(i - window + 1);
                }
            }

            return totalAnagrams;
        }

        private int[] BuildFrequency(string p)
        {
            var freq = new int[26];

            foreach (var c in p)
            {
                freq[c - 'a']++;
            }

            return freq;
        }
    }
}
