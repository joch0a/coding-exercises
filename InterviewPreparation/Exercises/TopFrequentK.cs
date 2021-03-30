using System.Collections.Generic;
using System.Linq;

namespace InterviewPreparation.Exercises
{
    class TopFrequentK
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

        public int FindKthLargest(int[] nums, int k)
        {
            return FindKthLargest(nums, k, 0, nums.Length - 1);
        }

        private int FindKthLargest(int[] nums, int k, int left, int right)
        {
            var pivotPosition = partition(nums, left, right);

            if (pivotPosition == nums.Length - k)
            {
                return nums[pivotPosition];
            } // [2,3,4,5,7t,8,9,10p,12]
            else if (pivotPosition < nums.Length - k)
            {
                return FindKthLargest(nums, k, pivotPosition + 1, right);
            }
            else
            {
                return FindKthLargest(nums, k, left, pivotPosition - 1);
            }
        }

        private int partition(int[] nums, int left, int right)
        {
            var pivotValue = nums[right];
            var pivotIndex = left;

            for (int i = left; i < right; i++)
            {
                if (pivotValue > nums[i])
                {
                    Swap(pivotIndex, i, nums);
                    pivotIndex++;
                }
            }

            Swap(pivotIndex, right, nums);

            return pivotIndex;
        }

        private void Swap(int i, int j, int[] arr)
        {
            int aux = arr[i];
            arr[i] = arr[j];
            arr[j] = aux;
        }
    }
}
