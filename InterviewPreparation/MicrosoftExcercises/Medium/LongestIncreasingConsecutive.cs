using System;
using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class LongestIncreasingConsecutive
    {
        public int LongestConsecutive(int[] nums)
        {
            var hs = new HashSet<int>(nums);
            var max = 0;
            foreach (var num in nums)
            {
                if (hs.Contains(num - 1))
                {
                    continue;
                }
                var currentStreak = 1;
                var current = num + 1;
                while (hs.Contains(current))
                {
                    current = current + 1;
                    currentStreak++;
                }
                max = Math.Max(max, currentStreak);
            }
            return max;
        }
    }
}
