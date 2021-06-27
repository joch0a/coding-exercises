namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class MinimumInSorted
    {
        public int FindMin(int[] nums)
        {
            var first = nums[0];
            var last = nums[nums.Length - 1];

            if (first <= last)
            {
                return first;
            }

            var low = 0;
            var high = nums.Length - 1;

            while (low < high)
            {
                var mid = low + (high - low) / 2;
                var actual = nums[mid];

                if (actual < nums[high])
                {
                    high = mid;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return nums[low];
        }
    }
}
