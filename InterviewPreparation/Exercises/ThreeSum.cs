using System;
using System.Collections.Generic;

namespace InterviewPreparation.Exercises
{
    public class ThreeSumClass
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> tuples = new List<IList<int>>();

            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i == 0 || (i > 0 && nums[i] != nums[i - 1]))
                {
                    var low = i + 1;
                    var high = nums.Length - 1;
                    var sum = -nums[i];

                    while (low < high)
                    {
                        if (nums[low] + nums[high] == sum)
                        {
                            tuples.Add(new int[] { nums[i], nums[low], nums[high] });

                            while (low < high && nums[low] == nums[low + 1])
                            {
                                low++;
                            }

                            while (low < high && nums[high] == nums[high - 1])
                            {
                                high--;
                            }

                            low++;
                            high--;
                        }
                        else if (nums[low] + nums[high] > sum)
                        {
                            high--;
                        }
                        else
                        {
                            low++;
                        }
                    }
                }
            }

            return tuples;
        }
    }
}
