using System;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class TriangleNumber
    {
        public int Solve(int[] nums)
        {
            var count = 0;
            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    var low = j + 1;
                    var high = nums.Length - 1;
                    var a = nums[i];
                    var b = nums[j];

                    while (low <= high)
                    {
                        var mid = low + (high - low) / 2;
                        var c = nums[mid];

                        if (a + b <= c)
                        {
                            high = mid - 1;
                        }
                        else
                        {
                            low = mid + 1;
                        }
                    }

                    count += low - j - 1;
                }
            }

            return count;
        }
    }
}
