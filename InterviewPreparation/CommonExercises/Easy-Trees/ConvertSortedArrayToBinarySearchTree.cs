using InterviewPreparation.Exercises;
using System;

namespace InterviewPreparation.CommonExercises.Easy_Trees
{
    class ConvertSortedArrayToBinarySearchTree
    {
        public TreeNode SortedArrayToBST(int[] nums)
        {
            return SortedArrayToBST(nums, 0, nums.Length - 1);
        }

        private TreeNode SortedArrayToBST(int[] nums, int low, int high)
        {
            if (low > high)
            {
                return null;
            }

            var mid = low + (high - low) / 2;

            Console.WriteLine(nums[mid]);
            var node = new TreeNode(nums[mid]);

            node.left = SortedArrayToBST(nums, low, mid - 1);
            node.right = SortedArrayToBST(nums, mid + 1, high);

            return node;
        }
    }
}
