namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class PathSum
    {
        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null)
            {
                return false;
            }

            if (sum - root.val == 0 && root.left == null && root.right == null)
            {
                return true;
            }

            return HasPathSum(root.left, sum - root.val) || HasPathSum(root.right, sum - root.val);
        }
    }
}
