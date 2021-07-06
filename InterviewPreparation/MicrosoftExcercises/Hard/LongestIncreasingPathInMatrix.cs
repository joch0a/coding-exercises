using System;
using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Hard
{
    class LongestIncreasingPathInMatrix
    {
        private readonly int[] Ys = new int[] { -1, 0, 0, 1 };
        private readonly int[] Xs = new int[] { 0, -1, 1, 0 };

        public int LongestIncreasingPath(int[][] matrix)
        {
            int max = -1;
            var memo = new Dictionary<string, int>();

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    max = Math.Max(max, LongestIncreasingPath(matrix, i, j, memo));
                }
            }

            return max;
        }

        private int LongestIncreasingPath(int[][] matrix, int row, int col, Dictionary<string, int> memo)
        {
            var key = $"{row}#{col}";

            if (memo.ContainsKey(key))
            {
                return memo[key];
            }

            var greaters = CalculateGreaters(matrix, row, col);

            if (greaters.Count == 0)
            {
                return 1;
            }

            var max = 0;

            foreach (var greater in greaters)
            {
                max = Math.Max(max, LongestIncreasingPath(matrix, greater[0], greater[1], memo) + 1);
            }

            memo.Add(key, max);

            return max;
        }

        public IList<int[]> CalculateGreaters(int[][] matrix, int row, int col)
        {
            var greaters = new List<int[]>();

            for (int index = 0; index < Ys.Length; index++)
            {
                var newRow = row + Ys[index];
                var newCol = col + Xs[index];

                if (newRow >= 0 &&
                   newRow < matrix.Length &&
                   newCol >= 0 &&
                   newCol < matrix[newRow].Length &&
                   matrix[row][col] < matrix[newRow][newCol])
                {
                    greaters.Add(new int[] { newRow, newCol });
                }
            }

            return greaters;
        }
    }
}
