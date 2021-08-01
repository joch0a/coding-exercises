using System;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class LongestPalindromeSubSeq
    {
        public int LongestPalindromeSubseq(string s)
        {
            var dp = new int[s.Length, s.Length];

            return DFS(s, 0, s.Length - 1, dp);
        }

        private int DFS(string s, int left, int right, int[,] dp)
        {
            if (left > right)
            {
                return 0;
            }

            if (left == right)
            {
                return 1;
            }

            if (dp[left, right] == 0)
            {
                if (s[left] == s[right])
                {
                    dp[left, right] = 2 + DFS(s, left + 1, right - 1, dp);
                }
                else
                {
                    dp[left, right] = Math.Max(DFS(s, left + 1, right, dp),
                                               DFS(s, left, right - 1, dp));
                }
            }

            return dp[left, right];
        }

        ///

        public int LongestPalindromeSubseqTabulation(string s)
        {
            int n = s.Length;
            int[,] dp = new int[n, n];

            for (int j = 0; j < n; j++)
            {
                dp[j, j] = 1;
                for (int i = j - 1; i >= 0; i--)
                {
                    if (s[i] == s[j])
                        dp[i, j] = dp[i + 1, j - 1] + 2;
                    else
                        dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
                }
            }

            return dp[n - 1, n - 1];
        }
    }
}
