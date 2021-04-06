using System;

namespace InterviewPreparation.Exercises.DynamicProgramming
{
    class LongestIncreasingSubsequence
    {
        // o(n2) time     o(n) space
        public int LengthOfLIS(int[] nums)
        {
            var LIS = new int[nums.Length];
            var max = 1;

            Array.Fill(LIS, 1);

            for (int i = 1; i < LIS.Length; i++) 
            {
                for (int j = 0; j < i; j++) 
                {
                    if (nums[i] > nums[j]) 
                    {
                        LIS[i]++;
                        max = Math.Max(max, LIS[i]);
                    }
                }
            }

            return max;
        }
    }
}
