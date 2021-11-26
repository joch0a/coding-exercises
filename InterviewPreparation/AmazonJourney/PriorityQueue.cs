using System.Collections.Generic;

namespace InterviewPreparation.AmazonJourney
{
    public class PriorityQueue<K> // min heap
    {
        private List<K> data;
        private IComparer<K> comparator;

        public PriorityQueue(IComparer<K> comparator)
        {
            data = new List<K>();
            this.comparator = comparator;
        }

        public int Count()
        {
            return data.Count;
        }

        public bool IsEmpty()
        {
            return data.Count == 0;
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

        private void HeapifyUp()
        {
            var index = data.Count - 1;

            while (index > 0)
            {
                var parentIndex = (index - 1) / 2;

                if (comparator.Compare(data[index], data[parentIndex]) >= 0)
                {
                    break;
                }

                Swap(index, parentIndex);
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

                Swap(index, minIndex);

                index = minIndex;
            }
        }

        private void Swap(int i, int j)
        {
            var aux = data[i];

            data[i] = data[j];
            data[j] = aux;
        }
    }
}
