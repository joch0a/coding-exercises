using System;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class MaxProduct
    {
        public int Solve(int[] nums)
        {
            var max = nums[0];
            var min = nums[0];
            int result = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                var actual1 = nums[i];
                var actual2 = nums[i] * max;
                var actual3 = nums[i] * min;

                min = Math.Min(actual1, Math.Min(actual2, actual3));
                max = Math.Max(actual1, Math.Max(actual2, actual3));
                result = Math.Max(result, max);
            }

            return result;
        }
    }
}
