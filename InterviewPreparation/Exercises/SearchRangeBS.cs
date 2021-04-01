namespace InterviewPreparation.Exercises
{
    public class SearchRangeBS
    {
        public int[] SearchRange(int[] nums, int target)
        {
            var initial = GetInitial(nums, target);
            var last = initial == -1 ? -1 : GetLast(nums, target);

            return new int[] { initial, last }; ;
        }

        private int GetInitial(int[] nums, int target)
        {
            int index = -1;
            int low = 0;
            int high = nums.Length - 1;

            while (low <= high)
            {
                var mid = low + (high - low) / 2;

                if (nums[mid] >= target)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }

                if (nums[mid] == target)
                {
                    index = mid;
                }
            }

            return index;
        }

        private int GetLast(int[] nums, int target)
        {
            int index = -1;
            int low = 0;
            int high = nums.Length - 1;

            while (low <= high)
            {
                var mid = low + (high - low) / 2;

                if (nums[mid] <= target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }

                if (nums[mid] == target)
                {
                    index = mid;
                }
            }

            return index;
        }
    }
}
