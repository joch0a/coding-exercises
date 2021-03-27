using System;

namespace InterviewPreparation.Exercises
{
    class IncreasingTripletSolutions
    {
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
    }
}
