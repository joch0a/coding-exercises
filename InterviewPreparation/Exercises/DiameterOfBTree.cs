namespace InterviewPreparation.Exercises
{
    public class DiameterOfBTree
    {
        private int diameter;
        public int DiameterOfBinaryTree(TreeNode root)
        {
            diameter = 0;

            LongestPath(root);

            return diameter;
        }

        public int LongestPath(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            var leftDepth = LongestPath(root.left);
            var rightDepth = LongestPath(root.right);

            diameter = Math.Max(diameter, leftDepth + rightDepth);

            return Math.Max(leftDepth, rightDepth) + 1;
        }
    }
}
