using System;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class MaximalSquare
    {
        public int Solve(char[][] matrix)
        {
            var m = matrix.Length;
            var n = matrix[0].Length;
            var dp = new int[m, n];
            var max = 0;

            //vertical
            for (int i = 0; i < m; i++)
            {
                dp[i, 0] = matrix[i][0] - '0';

                if (dp[i, 0] == 1)
                {
                    max = 1;
                }
            }

            //horizontal
            for (int j = 0; j < n; j++)
            {
                dp[0, j] = matrix[0][j] - '0';

                if (dp[0, j] == 1)
                {
                    max = 1;
                }
            }


            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (matrix[i][j] == '1')
                    {
                        dp[i, j] = Math.Min(Math.Min(dp[i - 1, j], dp[i, j - 1]), dp[i - 1, j - 1]) + 1;

                        max = Math.Max(max, dp[i, j] * dp[i, j]);
                    }
                }
            }

            return max;
        }
    }
}
