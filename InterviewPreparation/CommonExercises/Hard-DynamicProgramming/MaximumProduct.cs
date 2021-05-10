using System;

namespace InterviewPreparation.CommonExercises.Hard_DynamicProgramming
{
    class MaximumProduct
    {
        public int MaxProduct(int[] nums)
        {

            int max = nums[0], min = nums[0], res = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                int product1 = nums[i];

                // nums[i] and max are positive
                int product2 = nums[i] * max;

                // nums[i] and min are negative
                int product3 = nums[i] * min;

                max = Math.Max(Math.Max(product1, product2), product3);
                min = Math.Min(Math.Min(product1, product2), product3);

                res = Math.Max(res, max);
            }

            return res;
        }
    }
}
