using System;
using System.Linq;

namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class ThirdNumber
    {
        public int ThirdMax(int[] nums)
        {
            nums = nums.Distinct().ToArray();

            if (nums.Length == 1)
            {
                return nums[0];
            }

            if (nums.Length == 2)
            {
                return Math.Max(nums[0], nums[1]);
            }

            return ThirdMax(nums, 0, nums.Length - 1);
        }

        private int ThirdMax(int[] nums, int left, int right)
        {
            var position = partition(nums, left, right);

            if (position == 2)
            {
                return nums[position];
            }
            else if (position < 2)
            {
                return ThirdMax(nums, position + 1, right);
            }
            else
            {
                return ThirdMax(nums, left, position - 1);
            }
        }

        private int partition(int[] values, int left, int right)
        {
            int pivotValue = values[right];
            int pivotLocation = left;

            for (int i = left; i < right; i++)
            {
                if (pivotValue < values[i])
                {
                    Swap(pivotLocation, i, values);
                    pivotLocation++;
                }
            }

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
