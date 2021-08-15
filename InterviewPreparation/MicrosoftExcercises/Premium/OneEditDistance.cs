using System;

namespace InterviewPreparation.MicrosoftExcercises.Premium
{
    class OneEditDistance
    {
        public class Solution
        {
            public bool IsOneEditDistance(string s, string t)
            {
                var N = s.Length + 1;
                var M = t.Length + 1;

                var dp = new int[N, M];

                for (int j = 0; j < M; j++)
                {
                    dp[0, j] = j;
                }

                for (int i = 0; i < N; i++)
                {
                    dp[i, 0] = i;
                }

                for (int i = 1; i < N; i++)
                {
                    for (int j = 1; j < M; j++)
                    {
                        if (s[i - 1] == t[j - 1])
                        {
                            dp[i, j] = dp[i - 1, j - 1];
                        }
                        else
                        {
                            dp[i, j] = Math.Min(Math.Min(dp[i - 1, j], dp[i, j - 1]), dp[i - 1, j - 1]) + 1;
                        }
                    }
                }
                return dp[N - 1, M - 1] == 1;
            }
        }
    }
}
