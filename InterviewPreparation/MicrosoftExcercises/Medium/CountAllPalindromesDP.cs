using System;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class CountAllPalindromesDP
    {
        public int CountSubstrings(string s)
        {
            var n = s.Length;

            var dp = new bool[n, n];
            var total = 0;

            for (int i = 0; i < n; i++)
            {
                dp[i, i] = true;
            }

            var row = 0;

            for (int i = n - 1 - row; i >= 0; i--)
            {
                for (int j = i; j < n; j++)
                {
                    if (j == i)
                    {
                        dp[i, j] = true;
                        total++;
                    }
                    else if (s[i] == s[j] && (Math.Abs(i - j) == 1 || dp[i + 1, j - 1]))
                    {
                        dp[i, j] = true;
                        total++;
                    }
                }

                row++;
            }

            return total;
        }
    }
}
