using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class InterleavingString
    {
        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (s1.Length + s2.Length != s3.Length)
            {
                return false;
            }
            var cache = new Dictionary<string, bool>();

            return IsInterleave(s1, s2, s3, 0, 0, 0, cache);
        }
        private bool IsInterleave(string s1, string s2, string s3, int i1, int i2, int i3, Dictionary<string, bool> cache)
        {
            var key = $"{i1}${i2}${i3}";
            if (i3 == s3.Length)
            {
                return true;
            }
            if (cache.ContainsKey(key))
            {
                return cache[key];
            }
            bool result = false;
            if (!((i1 < s1.Length && s1[i1] == s3[i3]) || (i2 < s2.Length && s2[i2] == s3[i3])))
            {
                return false;
            }
            if (i1 < s1.Length && s1[i1] == s3[i3])
            {
                result = IsInterleave(s1, s2, s3, i1 + 1, i2, i3 + 1, cache);
            }
            if (i2 < s2.Length && s2[i2] == s3[i3])
            {
                result = result || IsInterleave(s1, s2, s3, i1, i2 + 1, i3 + 1, cache);
            }
            cache.Add(key, result);
            return result;
        }
    }
}
