using System;
using System.Collections.Generic;

namespace InterviewPreparation.CommonExercises.Hard_Graph
{
    class CriticalEdge
    {
        int time = 0;

        public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
        {
            var graph = new Dictionary<int, List<int>>();
            var result = new List<IList<int>>();

            // creates the graph
            foreach (var connection in connections)
            {
                int node1 = connection[0];
                int node2 = connection[1];

                if (!graph.ContainsKey(node1))
                {
                    graph.Add(node1, new List<int>());
                }

                if (!graph.ContainsKey(node2))
                {
                    graph.Add(node2, new List<int>());
                }

                graph[node1].Add(node2);
                graph[node2].Add(node1);
            }

            var disc = new int[n];
            var low = new int[n];

            Array.Fill(disc, -1);

            for (int i = 0; i < n; i++)
            {
                //if unvisited
                if (disc[i] == -1)
                {
                    DFS(i, i, low, disc, graph, result);
                }
            }

            return result;
        }

        public void DFS(int actualNode, int parent, int[] low, int[] disc, Dictionary<int, List<int>> graph, List<IList<int>> bridges)
        {
            low[actualNode] = time;
            disc[actualNode] = time;

            time++;

            for (int i = 0; i < graph[actualNode].Count; i++)
            {
                int nextNode = graph[actualNode][i];

                if (nextNode == parent)
                {
                    continue;
                }

                if (disc[nextNode] == -1)
                {
                    DFS(nextNode, actualNode, low, disc, graph, bridges);

                    low[actualNode] = Math.Min(low[actualNode], low[nextNode]);

                    if (low[nextNode] > disc[actualNode])
                    {
                        bridges.Add(new List<int>() { actualNode, nextNode });
                    }
                }
                else
                {
                    low[actualNode] = Math.Min(low[actualNode], disc[nextNode]);
                }
            }
        }
    }
}
