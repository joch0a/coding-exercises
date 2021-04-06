using System.Collections.Generic;
using System.Linq;

namespace InterviewPreparation.Exercises
{
    public class MinHeight
    {
        //Explanation over here https://www.youtube.com/watch?v=ZfzVig8UqBQ&ab_channel=SaiAnishMalla

        public Dictionary<int, IList<int>> edgesMap;

        public IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            edgesMap = new Dictionary<int, IList<int>>();

            if (n == 1)
            {
                return new List<int>() { 0 };
            }

            if (n == 2)
            {
                return new List<int>() { 0, 1 };
            }

            IList<int> leaves = new List<int>();
            IList<int> leavesTemp;

            //Create a representation of the edges to be retrieved O(1)
            for (int i = 0; i < edges.GetLength(0); i++)
            {
                CreateRoute(edges[i][0], edges[i][1]);
                CreateRoute(edges[i][1], edges[i][0]);
            }

            foreach (var edge in edgesMap.Keys)
            {
                if (edgesMap.ContainsKey(edge) && edgesMap[edge].Count == 1)
                {
                    leaves.Add(edge);
                }
            }

            while (edgesMap.Count > 2)
            {
                leavesTemp = new List<int>();

                foreach (var leaf in leaves)
                {
                    foreach (var edge in edgesMap[leaf])
                    {
                        edgesMap[edge].Remove(leaf);
                        if (edgesMap[edge].Count == 1)
                        {
                            leavesTemp.Add(edge);
                        }
                    }

                    edgesMap.Remove(leaf);
                }

                leaves = leavesTemp;
            }

            return edgesMap.Keys.ToList();
        }

        public void CreateRoute(int origin, int destination)
        {
            if (edgesMap.ContainsKey(origin))
            {
                edgesMap[origin].Add(destination);
            }
            else
            {
                edgesMap.Add(origin, new List<int>() { destination });
            }
        }
    }
}
