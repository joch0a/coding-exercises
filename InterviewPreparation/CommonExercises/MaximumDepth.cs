using System;

namespace InterviewPreparation.Exercises
{
    class MaximumDepth
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        // https://leetcode.com/problems/maximum-depth-of-binary-tree/submissions/

        public int MaxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            return MaxDepthAux(root, 1);
        }

        public int MaxDepthAux(TreeNode root, int sum)
        {
            if (root == null)
            {
                return sum;
            }

            if (root.left == null && root.right == null)
            {
                return sum;
            }

            return Math.Max(MaxDepthAux(root.left, sum + 1), MaxDepthAux(root.right, sum + 1));
        }

        //Internet solution
        public int MaxDepthAlt(TreeNode root)
        {
            if (root == null)
                return 0;

            int left = MaxDepthAlt(root.left);
            int right = MaxDepthAlt(root.right);

            return Math.Max(left, right) + 1;
        }
    }
}
