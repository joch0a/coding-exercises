using System;
using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    public class ChessKnightProbability
    {
        private int[] Xs = { -2, -1, 1, 2, -2, -1, 1, 2 };
        private int[] Ys = { -1, -2, -2, -1, 1, 2, 2, 1 };

        private double TotalPossibleMoves = 0;
        private double TotalPaths = 0;
        private IList<int[]>[,] ValidMoves;

        //THIS IS A TLE, the memoization here isnt the best. IF the memo is improved, then the solution will be accepted
        public double KnightProbability(int n, int k, int row, int column)
        {
            if (k == 0)
            {
                return 1;
            }

            ValidMoves = new IList<int[]>[n, n];

            CalculateTotalValidMoves(n, k, row, column);

            TotalPossibleMoves = Math.Pow(8, k);
            return TotalPaths / TotalPossibleMoves;
        }

        public void CalculateTotalValidMoves(int n, int k, int i, int j)
        {
            if (k == 0)
            {
                return;
            }

            IList<int[]> actualTotalValidMoves;

            if (ValidMoves[i, j] != null)
            {
                actualTotalValidMoves = ValidMoves[i, j];
            }
            else
            {
                actualTotalValidMoves = CalculateActualValidMoves(i, j, n);
            }

            foreach (var neighbour in actualTotalValidMoves)
            {
                if (k == 1)
                {
                    TotalPaths++;
                }

                CalculateTotalValidMoves(n, k - 1, neighbour[0], neighbour[1]);
            }

            if (ValidMoves[i, j] == null)
            {
                ValidMoves[i, j] = actualTotalValidMoves;
            }
        }

        private IList<int[]> CalculateActualValidMoves(int i, int j, int n)
        {
            var result = new List<int[]>();

            for (int x = 0; x < Xs.Length; x++)
            {
                var newI = i + Ys[x];
                var newJ = j + Xs[x];

                if (newI >= 0 && newI < n && newJ >= 0 && newJ < n)
                {
                    result.Add(new int[] { newI, newJ });
                }
            }

            return result;
        }
    }

    //memo optimized :)

    public class Solution
    {
        private int[] Xs = { -2, -1, 1, 2, -2, -1, 1, 2 };
        private int[] Ys = { -1, -2, -2, -1, 1, 2, 2, 1 };

        public double KnightProbability(int n, int k, int row, int column)
        {
            var cache = new double[n, n, k + 1];

            return KnightProbability(n, k, row, column, cache); ;
        }

        public double KnightProbability(int n, int k, int row, int column, double[,,] cache)
        {
            if (k == 0)
            {
                return 1;
            }

            if (cache[row, column, k] != 0.0)
            {
                return cache[row, column, k];
            }

            var neighbours = BuildNeighbours(row, column, n);
            var prob = 0.0;

            foreach (var neighbour in neighbours)
            {
                prob += KnightProbability(n, k - 1, neighbour[0], neighbour[1], cache);
            }

            cache[row, column, k] = prob / 8.0;

            return cache[row, column, k];
        }

        private IList<int[]> BuildNeighbours(int row, int col, int n)
        {
            var neighbours = new List<int[]>();

            for (int index = 0; index < Xs.Length; index++)
            {
                var newRow = row + Ys[index];
                var newCol = col + Xs[index];

                if (newRow >= 0 && newRow < n &&
                  newCol >= 0 && newCol < n)
                {
                    neighbours.Add(new int[] { newRow, newCol });
                }
            }

            return neighbours;
        }
    }
}
