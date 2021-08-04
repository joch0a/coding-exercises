using System;

namespace InterviewPreparation.MicrosoftExcercises.Hard
{
    class EditDistance
    {
        public int MinDistance(string word1, string word2)
        {
            var m = word1.Length + 1;
            var n = word2.Length + 1;
            var dp = new int[n, m];
            dp[0, 0] = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i == 0)
                    {
                        dp[i, j] = j;
                    }
                    else if (j == 0)
                    {
                        dp[i, j] = i;
                    }
                    else
                    {
                        if (word2[i - 1] == word1[j - 1])
                        {
                            dp[i, j] = dp[i - 1, j - 1];
                        }
                        else
                        {
                            dp[i, j] = Math.Min(Math.Min(dp[i - 1, j - 1], dp[i - 1, j]), dp[i, j - 1]) + 1;
                        }
                    }
                }
            }
            return dp[n - 1, m - 1];
        }
    }
}
