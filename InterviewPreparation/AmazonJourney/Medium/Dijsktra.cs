using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewPreparation.AmazonJourney.Medium
{
    class Solution
    {
        public List<int> dijkstra(int vertices, ref List<List<List<int>>> adj, int source)
        {
            var result = new int[vertices];
            var pq = new PriorityQueue<(int, int)>(new MyComparer());

            Array.Fill(result, int.MaxValue);

            result[source] = 0;
            pq.Push((0, source));

            while (pq.Count() > 0)
            {
                (var currentCost, var actual) = pq.Pop();

                if (currentCost > result[actual])
                {
                    continue;
                }

                foreach (var edge in adj[actual])
                {
                    var destination = edge[0];
                    var totalCost = currentCost + edge[1];

                    if (totalCost < result[destination])
                    {
                        result[destination] = totalCost;
                        pq.Push((totalCost, destination));
                    }
                }

            }

            return result.ToList();
        }
    }

    public class PriorityQueue<K>
    {
        private List<K> data;
        private IComparer<K> comparator;

        public PriorityQueue(IComparer<K> comparator)
        {
            this.comparator = comparator;
            data = new List<K>();
        }

        public int Count()
        {
            return data.Count;
        }

        public K Top()
        {
            return data[0];
        }

        public K Pop()
        {
            var item = data[0];
            var lastIndex = data.Count - 1;

            data[0] = data[lastIndex];
            data.RemoveAt(lastIndex);
            lastIndex--;

            HeapifyDown(lastIndex);

            return item;
        }

        public void Push(K item)
        {
            data.Add(item);

            HeapifyUp();
        }

        private void Swap(int i, int j)
        {
            var aux = data[i];

            data[i] = data[j];
            data[j] = aux;
        }

        private void HeapifyUp()
        {
            var index = data.Count - 1;

            while (index > 0)
            {
                var parentIndex = (index - 1) / 2;

                if (comparator.Compare(data[index], data[parentIndex]) >= 0)
                {
                    return;
                }

                Swap(parentIndex, index);

                index = parentIndex;
            }
        }

        private void HeapifyDown(int lastIndex)
        {
            var index = 0;

            while (true)
            {
                var minIndex = (index * 2) + 1;

                if (minIndex > lastIndex)
                {
                    return;
                }

                var right = minIndex + 1;

                if (right <= lastIndex && comparator.Compare(data[right], data[minIndex]) < 0)
                {
                    minIndex = right;
                }

                if (comparator.Compare(data[index], data[minIndex]) <= 0)
                {
                    return;
                }

                Swap(minIndex, index);
                index = minIndex;
            }
        }
    }

    public class MyComparer : IComparer<(int, int)>
    {
        public int Compare((int, int) A, (int, int) B)
        {
            return (A.Item1).CompareTo(B.Item1);
        }
    }
}
