namespace InterviewPreparation.Exercises
{
    class PathSum
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

        // https://leetcode.com/problems/path-sum/submissions/
        public class Solution
        {
            public bool HasPathSum(TreeNode root, int sum)
            {
                if (root == null)
                    return false;
                else if (root.left == null && root.right == null && root.val == sum)
                    return true;
                else
                    return HasPathSum(root.left, sum - root.val) || HasPathSum(root.right, sum - root.val);
            }
        }
    }
}
