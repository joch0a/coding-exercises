namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class FirstAndLast
    {
        public int[] SearchRange(int[] nums, int target)
        {
            if (nums.Length == 0)
            {
                return new int[] { -1, -1 };
            }

            var low = 0;
            var high = nums.Length - 1;

            while (low <= high)
            {
                var mid = low + (high - low) / 2;

                if (nums[mid] > target)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            int highest = high;

            if (high > nums.Length - 1 || high < 0 || nums[high] != target)
            {
                return new int[] { -1, -1 };
            }

            low = 0;
            high = highest;

            while (low <= high)
            {
                var mid = low + (high - low) / 2;
                var actual = nums[mid];

                if (actual >= target)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return new int[] { low, highest };
        }
    }
}
