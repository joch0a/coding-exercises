using System;
using System.Collections.Generic;

namespace InterviewPreparation.Exercises
{
    public class NumberOfIslands
    {
        public static int NumIslands(char[][] grid)
        {
            var numberOfIslands = 0;

            if (grid.Length > 0)
            {
                var visited = new bool[grid.Length, grid[0].Length];

                for (var i = 0; i < grid.Length; i++)
                {
                    for (var j = 0; j < grid[i].Length; j++)
                    {
                        if (!visited[i, j])
                        {
                            explore(grid, visited, ref numberOfIslands, i, j);
                        }
                    }
                }
            }

            return numberOfIslands;
        }

        private static void explore(char[][] grid, bool[,] visited, ref int numberOfIslands, int i, int j)
        {
            var nodesToVisit = new Stack<Tuple<int, int>>();
            var islandFound = false;

            nodesToVisit.Push(new Tuple<int, int>(i, j));

            while (nodesToVisit.Count > 0)
            {
                var actualNode = nodesToVisit.Pop();

                if (!visited[actualNode.Item1, actualNode.Item2])
                {
                    visited[actualNode.Item1, actualNode.Item2] = true;

                    if (grid[actualNode.Item1][actualNode.Item2] == '1')
                    {
                        islandFound = true;
                        var neighbours = GetNeighbours(grid, visited, actualNode.Item1, actualNode.Item2);

                        foreach (var neighbour in neighbours)
                        {
                            nodesToVisit.Push(neighbour);
                        }
                    }
                }
            }

            if (islandFound)
            {
                numberOfIslands++;
            }
        }

        private static IEnumerable<Tuple<int, int>> GetNeighbours(char[][] grid, bool[,] visited, int i, int j)
        {
            var neighbours = new List<Tuple<int, int>>();

            if (i > 0 && !visited[i - 1, j])
            {
                neighbours.Add(new Tuple<int, int>(i - 1, j));
            }

            if (j > 0 && !visited[i, j - 1])
            {
                neighbours.Add(new Tuple<int, int>(i, j - 1));
            }

            if (i < grid.Length - 1 && !visited[i + 1, j])
            {
                neighbours.Add(new Tuple<int, int>(i + 1, j));
            }

            if (j < grid[i].Length - 1 && !visited[i, j + 1])
            {
                neighbours.Add(new Tuple<int, int>(i, j + 1));
            }

            return neighbours;
        }

        //Code from Leetcode more optimized
        //public int NumIslands(char[][] grid)
        //{

        //    if (grid == null || grid.Length == 0)
        //    {
        //        return 0;
        //    }

        //    int numberOfIslands = 0;

        //    for (int i = 0; i < grid.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < grid[i].Length; j++)
        //        {
        //            char v = grid[i][j];
        //            if (v == '1')
        //            {
        //                numberOfIslands += sink(grid, i, j);
        //            }
        //        }
        //    }

        //    return numberOfIslands;
        //}

        //public int sink(char[][] grid, int i, int j)
        //{
        //    if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] == '0')
        //    {
        //        return 0;
        //    }

        //    grid[i][j] = '0';
        //    sink(grid, i, j + 1);
        //    sink(grid, i, j - 1);
        //    sink(grid, i + 1, j);
        //    sink(grid, i - 1, j);
        //    return 1;
        //}
    }
}
