using System.Collections.Generic;

namespace InterviewPreparation.CommonExercises.Hard_Graph
{
    class CourseSchedule
    {
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            var degrees = new int[numCourses];
            var lookup = new Dictionary<int, List<int>>();
            var queue = new Queue<int>();
            var topoSort = new List<int>();

            foreach (var edge in prerequisites)
            {
                if (!lookup.ContainsKey(edge[0]))
                {
                    lookup.Add(edge[0], new List<int>());
                }

                lookup[edge[0]].Add(edge[1]);
                degrees[edge[1]]++;
            }

            for (int i = 0; i < degrees.Length; i++)
            {
                if (degrees[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

            while (queue.Count > 0)
            {
                var actual = queue.Dequeue();

                topoSort.Add(actual);

                if (lookup.ContainsKey(actual))
                {
                    foreach (var node in lookup[actual])
                    {
                        degrees[node]--;

                        if (degrees[node] == 0)
                        {
                            queue.Enqueue(node);
                        }
                    }
                }
            }

            return topoSort.Count == numCourses;
        }
    }
}
