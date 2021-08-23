using InterviewPreparation.Exercises;
using System;

namespace InterviewPreparation.MicrosoftExcercises.Premium
{
    class LargestBST
    {
        public int LargestBSTSubtree(TreeNode root)
        {
            return FindMax(root).count;
        }

        private (int min, int max, int count) FindMax(TreeNode root)
        {
            if (root == null)
            {
                return (int.MaxValue, int.MinValue, 0);
            }

            var left = FindMax(root.left);
            var right = FindMax(root.right);

            if (root.val > left.max && root.val < right.min)
            {
                return (Math.Min(root.val, left.min), Math.Max(root.val, right.max), left.count + right.count + 1);
            }

            return (int.MinValue, int.MaxValue, Math.Max(left.count, right.count));
        }
    }
}
