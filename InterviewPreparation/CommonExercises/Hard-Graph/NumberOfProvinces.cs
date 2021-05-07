using InterviewPreparation.Shared;
using System.Collections.Generic;

namespace InterviewPreparation.CommonExercises.Hard_Graph
{
    class NumberOfProvinces
    {
        //Union-Find solution
        public int FindCircleNum(int[][] M)
        {

            int n = M.Length;
            var uf = new UnionFind(n);

            for (int i = 0; i < M.Length; i++)
            {
                for (int j = 0; j < M[0].Length; j++)
                {
                    if (M[i][j] == 1 && i != j) // i != j (can't be friend to oneself)
                        uf.Union(i, j);
                }
            }
            return uf.ConnectedComponents();
        }

        public int FindCircleNumBFS(int[][] isConnected)
        {
            var totalCount = 0;
            var visited = new HashSet<int>();

            for (int i = 0; i < isConnected.Length; i++)
            {
                if (!visited.Contains(i))
                {
                    totalCount++;
                    BFS(i, isConnected, visited);
                }
            }

            return totalCount;
        }

        public void BFS(int i, int[][] isConnected, HashSet<int> visited)
        {
            var queue = new Queue<int>();
            queue.Enqueue(i);

            while (queue.Count > 0)
            {
                var actual = queue.Dequeue();

                if (!visited.Contains(actual))
                {
                    visited.Add(actual);

                    for (int j = 0; j < isConnected[actual].Length; j++)
                    {
                        if (actual != j && !visited.Contains(j) && isConnected[actual][j] == 1)
                        {
                            queue.Enqueue(j);
                        }
                    }
                }
            }
        }
    }
}
