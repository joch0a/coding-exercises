using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Hard
{
    class UniquePaths3
    {
        public class Solution
        {

            private (int, int)[] directions = new (int, int)[]
            {
                (0, 1), (1, 0), (-1, 0), (0,-1)
            };

            public int UniquePathsIII(int[][] grid)
            {
                (int row, int col) start = (-1, -1);
                (int row, int col) dest = (-1, -1);

                var obstacles = 0;

                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        if (grid[i][j] == 1)
                        {
                            start = (i, j);
                        }

                        if (grid[i][j] == 2)
                        {
                            dest = (i, j);
                        }

                        if (grid[i][j] == -1)
                        {
                            obstacles++;
                        }
                    }
                }

                var noObstacles = (grid.Length * grid[0].Length) - obstacles;
                var total = 0;
                var visited = new HashSet<(int, int)>();

                visited.Add(start);

                Backtrack(start, dest, visited, ref total, noObstacles, grid);

                return total;
            }

            private void Backtrack((int, int) start,
                                   (int, int) dest,
                                   HashSet<(int, int)> visited,
                                   ref int total,
                                   int noObstacles,
                                   int[][] matrix)
            {
                if (start == dest)
                {
                    if (visited.Count == noObstacles)
                    {
                        total++;
                    }

                    return;
                }

                var neighbors = GetNeighbors(start, matrix);

                foreach (var neighbor in neighbors)
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);

                        Backtrack(neighbor, dest, visited, ref total, noObstacles, matrix);

                        visited.Remove(neighbor);
                    }
                }
            }

            private IList<(int, int)> GetNeighbors((int row, int col) start, int[][] matrix)
            {
                var neighbors = new List<(int, int)>();

                foreach (var (rowDirection, colDirection) in directions)
                {
                    var newRow = start.row + rowDirection;
                    var newCol = start.col + colDirection;

                    if (newRow >= 0 && newRow < matrix.Length &&
                       newCol >= 0 && newCol < matrix[newRow].Length &&
                       matrix[newRow][newCol] != -1)
                    {
                        neighbors.Add((newRow, newCol));
                    }
                }

                return neighbors;
            }
        }
    }
}
