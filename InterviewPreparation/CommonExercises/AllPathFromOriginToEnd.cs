using System.Collections.Generic;

namespace InterviewPreparation.CommonExercises
{
    class AllPathFromOriginToEnd
    {
        public class Solution
        {
            public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
            {
                IList<IList<int>> result = new List<IList<int>>();
                var current = new List<int>();
                current.Add(0);
                Backtrack(0, graph, current, result);

                return result;
            }

            private void Backtrack(int node, int[][] graph, List<int> current, IList<IList<int>> result)
            {
                if (node == graph.Length - 1)
                {
                    result.Add(current.ToList());
                }

                for (int i = 0; i < graph[node].Length; i++)
                {
                    if (graph[node][i] != -1)
                    {
                        var newNode = graph[node][i];
                        graph[node][i] = -1;
                        current.Add(newNode);
                        Backtrack(newNode, graph, current, result);
                        current.RemoveAt(current.Count - 1);
                        graph[node][i] = newNode;
                    }
                }
            }
        }
    }
}
