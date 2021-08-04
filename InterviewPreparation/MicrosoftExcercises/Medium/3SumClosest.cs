using System;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class _3SumClosest
    {
        public int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            int? minimum = null;

            for (int i = 0; i < nums.Length; i++)
            {
                var left = i + 1;
                var right = nums.Length - 1;

                while (left < right)
                {
                    var sum = nums[i] + nums[left] + nums[right];

                    if (sum == target)
                    {
                        return target;
                    }

                    if (sum > target)
                    {
                        right--;
                    }
                    else
                    {
                        left++;
                    }

                    if (minimum == null || Math.Abs(target - sum) < Math.Abs(target - minimum.Value))
                    {
                        minimum = sum;
                    }
                }
            }

            return minimum.Value;
        }
    }
}
