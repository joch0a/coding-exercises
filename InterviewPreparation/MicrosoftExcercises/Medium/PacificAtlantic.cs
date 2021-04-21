using System.Collections.Generic;
using System.Linq;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class PacificAtlantic
    {
        public IList<IList<int>> Solve(int[][] matrix)
        {
            var result = new List<IList<int>>();
            var visitedPacific = new bool[matrix.Length, matrix[0].Length];
            var visitedAtlantic = new bool[matrix.Length, matrix[0].Length];
            for (int j = 0; j < matrix[0].Length; j++)
            {
                BFS(matrix, 0, j, visitedPacific);
                BFS(matrix, matrix.Length - 1, j, visitedAtlantic);
            }
            for (int i = 0; i < matrix.Length; i++)
            {
                BFS(matrix, i, 0, visitedPacific);
                BFS(matrix, i, matrix[i].Length - 1, visitedAtlantic);
            }
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (visitedPacific[i, j] && visitedAtlantic[i, j])
                    {
                        result.Add((new int[] { i, j }).ToList());
                    }
                }
            }
            return result;
        }
        private void BFS(int[][] matrix, int i, int j, bool[,] visited)
        {
            if (!visited[i, j])
            {
                var queue = new Queue<int[]>();
                queue.Enqueue(new int[] { i, j });
                while (queue.Count > 0)
                {
                    var actual = queue.Dequeue();
                    if (!visited[actual[0], actual[1]])
                    {
                        visited[actual[0], actual[1]] = true;
                        var neighbours = GetNeighbours(matrix, actual[0], actual[1]);
                        foreach (var neighbour in neighbours)
                        {
                            queue.Enqueue(neighbour);
                        }
                    }
                }
            }
        }
        private IEnumerable<int[]> GetNeighbours(int[][] matrix, int i, int j)
        {
            IList<int[]> neighbours = new List<int[]>();
            if (i > 0 && matrix[i - 1][j] >= matrix[i][j])
            {
                neighbours.Add(new int[] { i - 1, j });
            }
            if (j > 0 && matrix[i][j - 1] >= matrix[i][j])
            {
                neighbours.Add(new int[] { i, j - 1 });
            }
            if (i < matrix.Length - 1 && matrix[i + 1][j] >= matrix[i][j])
            {
                neighbours.Add(new int[] { i + 1, j });
            }
            if (j < matrix[i].Length - 1 && matrix[i][j + 1] >= matrix[i][j])
            {
                neighbours.Add(new int[] { i, j + 1 });
            }
            return neighbours;
        }
    }
}
