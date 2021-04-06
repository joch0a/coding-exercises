namespace InterviewPreparation.Exercises
{
    public class PeakElement
    {
        public int FindPeakElement(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)  // IMPORTANT <=
            {
                var mid = left + (right - left) / 2; // (right + left) / 2 Could lead to overflow ==> https://stackoverflow.com/questions/25571359/why-we-write-lohi-lo-2-in-binary-search

                if (((mid == 0 || nums[mid - 1] <= nums[mid]) && (mid == nums.Length - 1 || nums[mid + 1] <= nums[mid])))
                {
                    return mid;
                }
                else if (mid > 0 && nums[mid - 1] > nums[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return 0;
        }
    }
}
