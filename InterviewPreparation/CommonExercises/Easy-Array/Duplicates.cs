using System.Collections.Generic;

namespace InterviewPreparation.CommonExercises.Easy_Array
{
    //https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/578/
    class Duplicates
    {
        public bool ContainsDuplicate(int[] nums)
        {
            var hs = new HashSet<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (hs.Contains(nums[i]))
                {
                    return true;
                }

                hs.Add(nums[i]);
            }

            return false;
        }
    }
}
