using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class BiPartite
    {
        public bool IsBipartite(int[][] graph)
        {
            var visited = new Dictionary<int, bool>();
            var queue = new Queue<int>();

            for (int i = 0; i < graph.Length; i++)
            {
                if (!visited.ContainsKey(i))
                {
                    queue.Enqueue(i);
                    bool actualSet = true;

                    while (queue.Count > 0)
                    {
                        var queueSize = queue.Count;

                        while (queueSize > 0)
                        {
                            var actual = queue.Dequeue();

                            if (visited.ContainsKey(actual))
                            {
                                if (visited[actual] != actualSet)
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                visited.Add(actual, actualSet);

                                foreach (var node in graph[actual])
                                {
                                    queue.Enqueue(node);
                                }
                            }

                            queueSize--;
                        }

                        actualSet = !actualSet;
                    }
                }
            }

            return true;
        }
    }
}
