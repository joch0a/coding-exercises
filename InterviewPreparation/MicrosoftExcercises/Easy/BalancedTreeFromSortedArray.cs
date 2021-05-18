using InterviewPreparation.Exercises;

namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class BalancedTreeFromSortedArray
    {
        public TreeNode SortedArrayToBST(int[] nums)
        {
            return SortedArrayToBST(nums, 0, nums.Length - 1);
        }

        public TreeNode SortedArrayToBST(int[] nums, int low, int high)
        {
            if (low > high)
            {
                return null;
            }
            else if (low == high)
            {
                return new TreeNode(nums[low]);
            }
            else
            {
                var mid = low + (high - low) / 2;
                var left = SortedArrayToBST(nums, low, mid - 1);
                var right = SortedArrayToBST(nums, mid + 1, high);

                return new TreeNode(nums[mid], left, right);
            }
        }
    }
}
