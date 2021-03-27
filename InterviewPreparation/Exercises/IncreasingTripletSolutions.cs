using System;

namespace InterviewPreparation.Exercises
{
    class IncreasingTripletSolutions
    {
        // Space o(n), time O(n)
        public bool IncreasingTriplet(int[] nums)
        {
            var left = new int[nums.Length];
            var right = new int[nums.Length];

            left[0] = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                left[i] = Math.Min(nums[i], left[i - 1]);
            }

            right[nums.Length - 1] = nums[nums.Length - 1];

            for (int i = nums.Length - 2; i >= 0; i--)
            {
                right[i] = Math.Max(nums[i], right[i + 1]);
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (left[i] < nums[i] && nums[i] < right[i])
                {
                    return true;
                }
            }

            return false;
        }

        // Space o(1), time O(n)
        public bool IncreasingTripletOptimized(int[] nums)
        {
            var first = int.MaxValue;
            var second = int.MaxValue;

            foreach (var num in nums)
            {
                if (num <= first)
                {
                    first = num;
                }
                else if (num <= second)
                {
                    second = num;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }
    }
}
}
