using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    public class ValidTreeSolution
    {
        public bool ValidTree(int n, int[][] edges)
        {
            if (n == 1)
            {
                return true;
            }

            var tree = GenerateTree(edges);

            return IsTree(tree, n);
        }

        private Dictionary<int, HashSet<int>> GenerateTree(int[][] edges)
        {
            var graph = new Dictionary<int, HashSet<int>>();

            foreach (var edge in edges)
            {
                var start = edge[0];
                var end = edge[1];

                if (!graph.ContainsKey(start))
                {
                    graph.Add(start, new HashSet<int>());
                }

                if (!graph.ContainsKey(end))
                {
                    graph.Add(end, new HashSet<int>());
                }

                graph[end].Add(start);
                graph[start].Add(end);
            }

            return graph;
        }

        private bool IsTree(Dictionary<int, HashSet<int>> graph, int n)
        {
            if (graph == null || graph.Count != n)
            {
                return false;
            }

            var queue = new Queue<int>();
            var visited = new HashSet<int>();

            queue.Enqueue(0);

            while (queue.Count > 0)
            {
                var actual = queue.Dequeue();

                if (visited.Contains(actual))
                {
                    return false;
                }

                visited.Add(actual);

                foreach (var node in graph[actual])
                {
                    graph[node].Remove(actual);

                    if (actual != node)
                    {
                        queue.Enqueue(node);
                    }
                }
            }

            if (visited.Count == n)
            {
                return true;
            }

            return false;
        }
    }
}
