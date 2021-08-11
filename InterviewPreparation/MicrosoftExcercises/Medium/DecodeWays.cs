using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class DecodeWays
    {
        public int NumDecodings(string s)
        {
            var cache = new Dictionary<int, int>();

            return NumDecodings(s, 0, cache);
        }

        private int NumDecodings(string s, int start, Dictionary<int, int> cache)
        {
            if (start == s.Length)
            {
                return 1;
            }

            if (cache.ContainsKey(start))
            {
                return cache[start];
            }

            var count = 0;

            for (int i = 1; i <= 2 && i + start <= s.Length; i++)
            {
                var actual = int.Parse(s.Substring(start, i));

                if (actual == 0 || actual > 26)
                {
                    break;
                }

                count += NumDecodings(s, i + start, cache);
            }

            cache[start] = count;

            return count;
        }
    }
}
