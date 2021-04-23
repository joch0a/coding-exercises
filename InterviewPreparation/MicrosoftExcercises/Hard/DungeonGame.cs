using System;

namespace InterviewPreparation.MicrosoftExcercises.Hard
{
    class DungeonGame
    {
        public int CalculateMinimumHP(int[][] dungeon)
        {
            int m = dungeon.Length;
            int n = dungeon[0].Length;
            var dp = new int[m, n];

            dp[m - 1, n - 1] = dungeon[m - 1][n - 1] > 0 ? 0 : dungeon[m - 1][n - 1];

            for (int j = n - 2; j >= 0; j--)
            {
                var val = dungeon[m - 1][j] + dp[m - 1, j + 1];
                dp[m - 1, j] = val > 0 ? 0 : val;
            }

            for (int i = m - 2; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    if (j == n - 1)
                    {
                        var val = dp[i + 1, j] + dungeon[i][j];
                        dp[i, j] = val > 0 ? 0 : val;
                    }
                    else
                    {
                        var val = Math.Max(dp[i, j + 1], dp[i + 1, j]) + dungeon[i][j];
                        dp[i, j] = val > 0 ? 0 : val;
                    }
                }
            }

            return dp[0, 0] > 0 ? 1 : Math.Abs(dp[0, 0]) + 1;
        }
    }
}
