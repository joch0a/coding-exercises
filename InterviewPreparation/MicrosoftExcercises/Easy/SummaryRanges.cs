using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class SummaryRanges
    {
        public IList<string> Solve(int[] nums)
        {
            var result = new List<string>();
            int i = 0;
            int? prev;

            while (i < nums.Length)
            {
                var start = nums[i];
                prev = null;

                while (i < nums.Length && (prev == null || (nums[i] - prev == 1)))
                {
                    prev = nums[i];
                    i++;
                }

                var range = start == prev ? $"{start}" : $"{start}->{prev}";

                result.Add(range);
            }

            return result;
        }
    }
}
