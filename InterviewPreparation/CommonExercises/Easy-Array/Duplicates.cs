using System.Collections.Generic;

namespace InterviewPreparation.CommonExercises.Easy_Array
{
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
}
