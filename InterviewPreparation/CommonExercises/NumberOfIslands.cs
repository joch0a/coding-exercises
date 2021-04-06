using System;
using System.Collections.Generic;

namespace InterviewPreparation.Exercises
{
    public class NumberOfIslands
    {
        public int NumIslands(char[][] grid)
        {
            if (grid == null)
            {
                return 0;
            }

            var numberOfIslands = 0;

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid[i].GetLength(0); j++)
                {
                    if (grid[i][j] == '1')
                    {
                        visitIsland(grid, i, j);
                        numberOfIslands++;
                    }
                }
            }

            return numberOfIslands;
        }

        public void visitIsland(char[][] grid, int i, int j)
        {
            var queue = new Queue<Tuple<int, int>>();

            queue.Enqueue(new Tuple<int, int>(i, j));

            while (queue.Count > 0)
            {
                var actual = queue.Dequeue();
                if (grid[actual.Item1][actual.Item2] == '1')
                {
                    grid[actual.Item1][actual.Item2] = '0';
                    calculateNeighbours(grid, queue, actual.Item1, actual.Item2);
                }
            }
        }

        public void calculateNeighbours(char[][] grid, Queue<Tuple<int, int>> queue, int i, int j)
        {
            if (i > 0 && grid[i - 1][j] == '1')
            {
                queue.Enqueue(new Tuple<int, int>(i - 1, j));
            }

            if (i < grid.Length - 1 && grid[i + 1][j] == '1')
            {
                queue.Enqueue(new Tuple<int, int>(i + 1, j));
            }

            if (j > 0 && grid[i][j - 1] == '1')
            {
                queue.Enqueue(new Tuple<int, int>(i, j - 1));
            }

            if (j < grid[i].Length - 1 && grid[i][j + 1] == '1')
            {
                queue.Enqueue(new Tuple<int, int>(i, j + 1));
            }
        }
    }
}
