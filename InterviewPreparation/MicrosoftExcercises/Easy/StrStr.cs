namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class StrStr
    {
        public int Solve1(string haystack, string needle)
        {
            if (needle.Length == 0)
            {
                return 0;
            }

            for (int i = 0; i < haystack.Length && i + needle.Length - 1 <= haystack.Length - 1; i++)
            {
                int j = 0;
                int hi = i;

                while (j < needle.Length && hi < haystack.Length && needle[j] == haystack[hi])
                {
                    j++;
                    hi++;
                }

                if (j == needle.Length)
                {
                    return i;
                }
            }

            return -1;
        }

        public int SolveKMP(string haystack, string needle)
        {
            if (needle.Length == 0)
            {
                return 0;
            }

            var lps = CalculateLPS(needle);

            var i = 0;
            var j = 0;

            while (i < haystack.Length && j < needle.Length)
                if (haystack[i] == needle[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    if (j > 0)
                    {
                        j = lps[j - 1];
                    }
                    else
                    {
                        i++;
                    }
                }

            return j == needle.Length ? i - j : -1;
        }
        public int[] CalculateLPS(string needle)
        {
            var lps = new int[needle.Length];

            var i = 1;
            var len = 0;

            lps[0] = 0;

            while (i < lps.Length)
            {
                if (needle[i] == needle[len])
                {
                    len++;
                    lps[i] = len;
                    i++;
                }
                else
                {
                    if (len != 0)
                    {
                        len = lps[len - 1];
                    }
                    else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
            }

            return lps;
        }
    }
}
