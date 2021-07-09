using InterviewPreparation.Exercises;
using System;

namespace InterviewPreparation.MicrosoftExcercises.Hard
{
    class MaximumPathBinaryTree
    {
        public int MaxPathSum(TreeNode root)
        {
            int max = int.MinValue;

            MaxPathSumOptimized(root, ref max);

            return max;
        }

        // readable
        private int MaxPathSum(TreeNode root, ref int max)
        {
            if (root == null)
            {
                return 0;
            }

            var left = MaxPathSum(root.left, ref max);
            var right = MaxPathSum(root.right, ref max);

            var max1 = Math.Max(left + root.val, right + root.val);
            var max2 = Math.Max(max1, root.val);

            max = Math.Max(max, Math.Max(left + right + root.val, max2));

            return Math.Max(Math.Max(left, right) + root.val, root.val);
        }

        // cool trick
        private int MaxPathSumOptimized(TreeNode root, ref int max)
        {
            if (root == null)
            {
                return 0;
            }

            var left = Math.Max(0, MaxPathSumOptimized(root.left, ref max));
            var right = Math.Max(0, MaxPathSumOptimized(root.right, ref max));

            max = Math.Max(max, left + right + root.val);

            return Math.Max(left, right) + root.val;
        }
    }
}
