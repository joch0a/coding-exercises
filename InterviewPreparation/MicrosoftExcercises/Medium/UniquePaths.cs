namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class UniquePaths
    {
        public int Solve(int m, int n)
        {
            var dp = new int[m, n];

            for (int j = 0; j < n; j++)
            {
                dp[0, j] = 1;
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j == 0)
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                    }
                }
            }

            return dp[m - 1, n - 1];
        }
    }
}
