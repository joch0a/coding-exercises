using System;
using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class FindAllNumbersDisappearedArray
    {
        //The idea behind this is using the values of the array as indexes and negating the values inside those indexes. After that all the positive numbers will be the missing ones.
        public IList<int> SolveNegateMethod(int[] nums)
        {
            var result = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                nums[Math.Abs(nums[i]) - 1] = Math.Abs(nums[Math.Abs(nums[i]) - 1]) * (-1);
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    result.Add(i + 1);
                }
            }

            return result;
        }

        // The idea behind this approach is similar, using the numbes as indexes and swap until you are using the proper value or u enter on a cycle.
        // Then check if nums[i] != i + 1 > missing
        public IList<int> SolveSwapping(int[] nums)
        {
            var result = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                while (nums[i] != i + 1 && nums[nums[i] - 1] != nums[i])
                {
                    var tmp = nums[i];
                    nums[i] = nums[tmp - 1];
                    nums[tmp - 1] = tmp;
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != i + 1)
                {
                    result.Add(i + 1);
                }
            }

            return result;
        }
    }
}
