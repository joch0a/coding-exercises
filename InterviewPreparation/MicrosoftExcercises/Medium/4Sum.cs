using System;
using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    public class _4Sum
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);
            IList<IList<int>> result = new List<IList<int>>();
            int a = 0;
            while (a < nums.Length)
            {
                if (a == 0 || nums[a] != nums[a - 1])
                {
                    for (int b = a + 1; b < nums.Length - 2; b++)
                    {
                        if (b > a + 1 && nums[b] == nums[b - 1])
                        {
                            continue;
                        }

                        var c = b + 1;
                        var d = nums.Length - 1;

                        while (c < d)
                        {
                            var sum = nums[a] + nums[b] + nums[c] + nums[d];

                            if (sum == target)
                            {
                                result.Add(new int[] { nums[a], nums[b], nums[c], nums[d] });

                                do
                                {
                                    c++;
                                } while (c < d && nums[c] == nums[c - 1]);

                                do
                                {
                                    d--;
                                } while (c < d && nums[d] == nums[d + 1]);
                            }
                            else if (sum < target)
                            {
                                do
                                {
                                    c++;
                                } while (c < d && nums[c] == nums[c - 1]);
                            }
                            else
                            {
                                do
                                {
                                    d--;
                                } while (c < d && nums[d] == nums[d + 1]);
                            }


                        }
                    }
                }

                a++;
            }

            return result;
        }
    }
}
