using System;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class MinimumSubarraySumK
    {
        public int MinSubArrayLen(int target, int[] nums)
        {
            var min = int.MaxValue;
            var sum = 0;
            var left = 0;
            var right = 0;

            while (left < nums.Length && right < nums.Length)
            {
                while (right < nums.Length && sum < target)
                {
                    sum += nums[right];
                    right++;
                }

                while (sum >= target)
                {
                    min = Math.Min(min, right - left);
                    sum -= nums[left];
                    left++;
                }
            }

            return min == int.MaxValue ? 0 : min;
        }
    }
}
