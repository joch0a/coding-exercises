namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class PivotIndex
    {
        public int Solve(int[] nums)
        {
            if (nums.Length == 1)
            {
                return 0;
            }
            var n = nums.Length;
            var suffixSum = new int[n];
            suffixSum[n - 1] = nums[n - 1];
            for (int i = n - 2; i > 0; i--)
            {
                suffixSum[i] = nums[i] + suffixSum[i + 1];
            }
            if (suffixSum[1] == 0)
            {
                return 0;
            }
            var prefixSum = nums[0];
            for (int i = 1; i <= n - 2; i++)
            {
                if (prefixSum == suffixSum[i + 1])
                {
                    return i;
                }
                prefixSum += nums[i];
            }
            if (prefixSum == 0)
            {
                return n - 1;
            }
            return -1;
        }
    }
}
