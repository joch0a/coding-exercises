using System;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class LIS
    {
        public int LengthOfLIS(int[] nums)
        {
            var max = 1;
            var LIS = new int[nums.Length];

            Array.Fill(LIS, 1);

            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i])
                    {
                        LIS[i] = Math.Max(LIS[i], LIS[j] + 1);
                        max = Math.Max(LIS[i], max);
                    }
                }
            }

            return max;
        }
    }
}
