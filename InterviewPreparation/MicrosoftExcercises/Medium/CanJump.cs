using System;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class CanJump
    {
        public bool Solve(int[] nums)
        {
            int canWalk = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (canWalk == 0) 
                {
                    return false;
                }

                canWalk--;
                canWalk = Math.Max(canWalk, nums[i]);
            }
            return true;
        }
    }
}
