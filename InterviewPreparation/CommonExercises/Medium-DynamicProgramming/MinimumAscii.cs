using System;

namespace InterviewPreparation.CommonExercises.Medium_DynamicProgramming
{
    class MinimumAscii
    {
        public int MinimumDeleteSum(string s1, string s2)
        {
            var m = s1.Length + 1;
            var n = s2.Length + 1;
            var dp = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        dp[i, j] = 0;
                    }
                    else if (i == 0)
                    {
                        dp[i, j] = dp[i, j - 1] + (int)s2[j - 1];
                    }
                    else if (j == 0)
                    {
                        dp[i, j] = dp[i - 1, j] + (int)s1[i - 1];
                    }
                    else
                    {
                        if (s1[i - 1] == s2[j - 1])
                        {
                            dp[i, j] = dp[i - 1, j - 1];
                        }
                        else
                        {
                            dp[i, j] = Math.Min((int)s1[i - 1] + dp[i - 1, j], (int)s2[j - 1] + dp[i, j - 1]);
                        }
                    }
                }
            }

            return dp[m - 1, n - 1];
        }
    }
}
