using InterviewPreparation.Shared;
using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class CloneGraph
    {
        public GraphNode Solve(GraphNode node)
        {
            if (node == null)
            {
                return node;
            }

            var dict = new Dictionary<GraphNode, GraphNode>();
            var queue = new Queue<GraphNode>();

            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                var actual = queue.Dequeue();

                if (!dict.ContainsKey(actual))
                {
                    dict.Add(actual, new GraphNode(actual.val));

                    foreach (var child in actual.neighbors)
                    {
                        if (!dict.ContainsKey(child))
                        {
                            queue.Enqueue(child);
                        }
                    }
                }
            }

            foreach (var actualGraphNode in dict.Keys)
            {
                foreach (var child in actualGraphNode.neighbors)
                {
                    dict[actualGraphNode].neighbors.Add(dict[child]);
                }
            }

            return dict[node];
        }
    }
}
