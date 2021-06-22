using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class CourseScheduleII
    {
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            var graph = new Dictionary<int, HashSet<int>>();
            var degrees = new int[numCourses];
            var candidates = new Stack<int>();
            var order = new int[numCourses];

            foreach (var prerequisite in prerequisites)
            {
                var toNode = prerequisite[0];
                var fromNode = prerequisite[1];

                if (!graph.ContainsKey(toNode))
                {
                    graph.Add(toNode, new HashSet<int>());
                }

                if (!graph.ContainsKey(fromNode))
                {
                    graph.Add(fromNode, new HashSet<int>());
                }

                graph[toNode].Add(fromNode);
                graph[fromNode].Add(toNode);

                degrees[toNode]++;
            }

            for (int i = 0; i < degrees.Length; i++)
            {
                if (degrees[i] == 0)
                {
                    candidates.Push(i);
                }
            }

            var orderIndex = 0;

            while (candidates.Count > 0)
            {
                var actual = candidates.Pop();
                order[orderIndex] = actual;
                orderIndex++;
                if (graph.ContainsKey(actual))
                {
                    foreach (var node in graph[actual])
                    {
                        degrees[node]--;

                        if (degrees[node] == 0)
                        {
                            candidates.Push(node);
                        }

                        graph[node].Remove(actual);
                    }
                }
            }

            return order.Length == orderIndex ? order : new int[0];
        }
    }
}
