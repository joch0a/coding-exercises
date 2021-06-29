namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class UniquePathsII
    {
        public int UniquePathsWithObstacles(int[][] grid)
        {
            var n = grid.Length;
            var m = grid[0].Length;

            if (n < 1 || m < 1 || grid[0][0] == 1)
            {
                return 0;
            }

            var dp = new int[n, m];

            dp[0, 0] = 1;

            for (int j = 1; j < m; j++)
            {
                dp[0, j] = grid[0][j] == 1 ? 0 : dp[0, j - 1];
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j == 0)
                    {
                        dp[i, j] = grid[i][j] == 1 ? 0 : dp[i - 1, j];
                    }
                    else
                    {
                        dp[i, j] = grid[i][j] == 1 ? 0 : dp[i - 1, j] + dp[i, j - 1];
                    }
                }
            }

            return dp[n - 1, m - 1];
        }
    }
}
