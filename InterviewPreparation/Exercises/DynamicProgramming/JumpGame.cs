using System;

namespace InterviewPreparation.Exercises.DynamicProgramming
{
    public class JumpGame
    {
        public bool CanJump(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return false;
            }

            var maxJumps = new int[nums.Length];

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (i == 0)
                {
                    maxJumps[0] = nums[0];
                }
                else
                {
                    maxJumps[i] = Math.Max(maxJumps[i - 1] - 1, nums[i]);
                }

                if (maxJumps[i] == 0)
                {
                    return false;
                }
            }

            return true;
        }


    }
}
