namespace InterviewPreparation.MicrosoftExcercises.Hard
{
    class WildcardMatching
    {
        public bool IsMatch(string s, string p)
        {
            var cache = new bool?[s.Length + 1, p.Length + 1];

            return IsMatch(s, p, 0, 0, cache);
        }

        private bool IsMatch(string s, string p, int sI, int pI, bool?[,] cache)
        {
            if (pI == p.Length)
            {
                return s.Length == sI;
            }

            if (cache[sI, pI] != null)
            {
                return cache[sI, pI].Value;
            }

            var firstMatch = sI < s.Length && (s[sI] == p[pI] || p[pI] == '?');
            var result = false;

            if (p[pI] == '*')
            {
                result = IsMatch(s, p, sI, pI + 1, cache) || (sI < s.Length && IsMatch(s, p, sI + 1, pI, cache));
            }
            else
            {
                result = firstMatch && IsMatch(s, p, sI + 1, pI + 1, cache);
            }

            cache[sI, pI] = result;

            return result;
        }
    }
}
