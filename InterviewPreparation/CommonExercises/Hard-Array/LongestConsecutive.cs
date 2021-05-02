using System;
using System.Collections.Generic;

namespace InterviewPreparation.CommonExercises.Hard_Array
{
    class LongestConsecutive
    {
        public int Solve(int[] nums)
        {
            var maxLongestStreak = 0;

            var hs = new HashSet<int>(nums);

            for (int i = 0; i < nums.Length; i++)
            {
                var actual = nums[i];

                if (!hs.Contains(actual - 1))
                {
                    var longestStreak = 0;

                    while (hs.Contains(actual))
                    {
                        longestStreak++;
                        actual++;
                    }

                    maxLongestStreak = Math.Max(maxLongestStreak, longestStreak);
                }
            }

            return maxLongestStreak;
        }
    }
}
