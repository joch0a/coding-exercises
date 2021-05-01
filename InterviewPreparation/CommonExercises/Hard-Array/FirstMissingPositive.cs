using System;
using System.Linq;

namespace InterviewPreparation.CommonExercises.Hard_Array
{
    class FirstMissingPositive
    {
        public int Solve(int[] nums)
        {
            nums = nums.Where(num => num > 0).ToHashSet().ToArray();

            Array.Sort(nums);

            for (int i = 1; i < int.MaxValue; i++)
            {
                if (i == nums.Length + 1 || i != nums[i - 1])
                {
                    return i;
                }
            }

            return 301;
        }
    }
}
