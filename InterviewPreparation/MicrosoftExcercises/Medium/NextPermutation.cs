﻿using System;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class NextPermutation
    {
        public void Solve(int[] nums)
        {
            if (nums.Length >= 2)
            {
                int n = nums.Length;
                int i = n - 2;

                while (i >= 0 && nums[i] >= nums[i + 1])
                {
                    i--;
                }

                if (i >= 0)
                {
                    int j = nums.Length - 1;

                    while (j >= 0 && nums[j] <= nums[i])
                    {
                        j--;
                    }

                    Swap(nums, i, j);
                }

                Array.Reverse(nums, i + 1, n - (i + 1));
            }
        }
        
        public void Swap(int[] nums, int i, int j)
        {
            var tmp = nums[i];

            nums[i] = nums[j];
            nums[j] = tmp;
        }

        public void NextPermutation2(int[] nums)
        {
            var index = nums.Length - 1;

            while (index >= 1 && nums[index - 1] >= nums[index])
            {
                index--;
            }

            if (index == 0)
            {
                Array.Sort(nums);

                return;
            }

            var placeToSwap = index - 1;

            index = nums.Length - 1;

            while (index >= 1 && nums[placeToSwap] >= nums[index])
            {
                index--;
            }

            Swap(nums, index, placeToSwap);

            var left = placeToSwap + 1;
            var right = nums.Length - 1;

            while (left < right)
            {
                Swap(nums, left, right);
                left++;
                right--;
            }
        }
    }
}
