using System.Collections.Generic;
using System.Linq;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class TOPKFrequent
    {
        public int[] TopKFrequent(int[] nums, int k)
        {
            var frequencies = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (!frequencies.ContainsKey(num))
                {
                    frequencies.Add(num, 1);
                }
                else
                {
                    frequencies[num] += 1;
                }
            }

            var keys = frequencies.Keys.ToArray();
            var values = frequencies.Values.ToArray();

            return TopKFrequent(values, keys, k, 0, values.Length - 1);
        }

        private int[] TopKFrequent(int[] values, int[] keys, int k, int left, int right)
        {
            var pivotPosition = partition(values, k, left, right, keys);

            if (pivotPosition == values.Length - k)
            {
                return keys.Skip(pivotPosition).Take(k).ToArray();
            }
            else if (pivotPosition < values.Length - k)
            {
                return TopKFrequent(values, keys, k, pivotPosition + 1, right);
            }
            else
            {
                return TopKFrequent(values, keys, k, left, pivotPosition - 1);
            }
        }

        private int partition(int[] values, int k, int left, int right, int[] keys)
        {
            int pivotValue = values[right];
            int pivotLocation = left;

            for (int i = left; i < right; i++)
            {
                if (pivotValue > values[i])
                {
                    Swap(pivotLocation, i, keys);
                    Swap(pivotLocation, i, values);
                    pivotLocation++;
                }
            }

            Swap(pivotLocation, right, keys);
            Swap(pivotLocation, right, values);

            return pivotLocation;
        }

        private void Swap(int i, int j, int[] arr)
        {
            int aux = arr[i];
            arr[i] = arr[j];
            arr[j] = aux;
        }
    }
}
