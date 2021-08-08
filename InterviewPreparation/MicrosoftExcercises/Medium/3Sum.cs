using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class _3Sum
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var result = new List<IList<int>>();
            Array.Sort(nums);
            int i = 0;
            while (i < nums.Length - 2)
            {
                if (i == 0 || (i > 0 && nums[i] != nums[i - 1]))
                {
                    int left = i + 1;
                    int right = nums.Length - 1;
                    int target = nums[i];
                    while (left < right)
                    {
                        if (nums[left] + nums[right] == -target)
                        {
                            result.Add((new int[] { target, nums[left], nums[right] }).ToList());
                            while (left < right && nums[left] == nums[left + 1])
                            {
                                left++;
                            }
                            while (left < right && nums[right] == nums[right - 1])
                            {
                                right--;
                            }
                            left++;
                            right--;
                        }
                        else if (nums[left] + nums[right] < -target)
                        {
                            left++;
                        }
                        else
                        {
                            right--;
                        }
                    }
                }
                i++;
            }
            return result;
        }

        public IList<IList<int>> ThreeSum2(int[] nums)
        {
            Array.Sort(nums);
            var result = new List<IList<int>>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (i != 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }

                var left = i + 1;
                var right = nums.Length - 1;

                while (left < right)
                {
                    var sum = nums[i] + nums[left] + nums[right];

                    if (sum == 0)
                    {
                        result.Add(new List<int>() { nums[i], nums[left], nums[right] });

                        left++;
                        right--;

                        while (left < right && left > 0 && nums[left] == nums[left - 1])
                        {
                            left++;
                        }

                        while (left < right && right < nums.Length - 1 && nums[right] == nums[right + 1])
                        {
                            right--;
                        }
                    }
                    else if (sum > 0)
                    {
                        right--;

                        while (left < right && right < nums.Length - 1 && nums[right] == nums[right + 1])
                        {
                            right--;
                        }
                    }
                    else
                    {
                        left++;

                        while (left < right && left > 0 && nums[left] == nums[left - 1])
                        {
                            left++;
                        }
                    }
                }
            }

            return result;
        }
    }
}
