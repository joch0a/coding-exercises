using System;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class CountSquares
    {
        public int Solve(int[][] matrix)
        {
            var M = matrix.Length;
            var N = matrix[0].Length;
            var dp = new int[M + 1, N + 1];
            var total = 0;

            for (int i = 1; i <= M; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    if (matrix[i - 1][j - 1] == 1)
                    {
                        dp[i, j] = Math.Min(
                                        Math.Min(dp[i - 1, j - 1], dp[i - 1, j]),
                                        dp[i, j - 1]) + 1;

                        total += dp[i, j];
                    }
                }
            }

            return total;
        }
    }
}
