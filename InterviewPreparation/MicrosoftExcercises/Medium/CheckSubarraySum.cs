using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class CheckSubarraySum
    {
        public bool Solve(int[] nums, int k)
        {
            var indexes = new Dictionary<int, int>()
        {
            {0, -1}
        };
            var sum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                sum = (sum + nums[i]) % k;

                if (indexes.ContainsKey(sum))
                {
                    var index = indexes[sum];

                    if (i - index > 1)
                    {
                        return true;
                    }
                }
                else
                {
                    indexes.Add(sum, i);
                }
            }

            return false;
        }
    }
}
