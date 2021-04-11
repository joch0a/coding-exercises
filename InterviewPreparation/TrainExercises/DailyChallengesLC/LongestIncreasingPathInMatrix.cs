using System;
using System.Collections.Generic;

namespace InterviewPreparation.TrainExercises.DailyChallengesLC
{
    class LongestIncreasingPathInMatrix
    {
        //HARD Time limit exceed
        public int[,] cache;

        public int LongestIncreasingPath(int[][] matrix)
        {
            if (matrix.Length == 0)
            {
                return 0;
            }

            cache = new int[matrix.Length, matrix[0].Length];
            int max = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    var actualPath = DFS(matrix, i, j);
                    max = Math.Max(max, actualPath);
                }
            }

            return max;
        }

        private int DFS(int[][] matrix, int i, int j)
        {
            if (cache[i, j] > 0)
            {
                return cache[i, j];
            }

            var neighbours = CalculateNeighbours(matrix, i, j);

            int max = 0;

            foreach (var neighbour in neighbours)
            {
                var longest = DFS(matrix, neighbour[0], neighbour[1]);
                max = Math.Max(max, longest);
            }

            cache[i, j] = max + 1;

            return cache[i, j];
        }

        private List<int[]> CalculateNeighbours(int[][] matrix, int i, int j)
        {
            List<int[]> list = new List<int[]>();

            if (i > 0 && matrix[i - 1][j] > matrix[i][j])
            {
                list.Add(new int[] { i - 1, j });
            }

            if (j > 0 && matrix[i][j - 1] > matrix[i][j])
            {
                list.Add(new int[] { i, j - 1 });
            }

            if (i < matrix.Length - 1 && matrix[i + 1][j] > matrix[i][j])
            {
                list.Add(new int[] { i + 1, j });
            }

            if (j < matrix[i].Length - 1 && matrix[i][j + 1] > matrix[i][j])
            {
                list.Add(new int[] { i, j + 1 });
            }

            return list;
        }
    }
}
