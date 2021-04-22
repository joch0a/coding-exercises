using InterviewPreparation.Exercises;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class TrimBST
    {
        public TreeNode Solve(TreeNode root, int low, int high)
        {
            return PostOrder(root, low, high);
        }

        public TreeNode PostOrder(TreeNode root, int low, int high)
        {
            if (root == null)
            {
                return root;
            }
            else
            {
                root.left = PostOrder(root.left, low, high);
                root.right = PostOrder(root.right, low, high);

                if (root.val >= low && root.val <= high)
                {
                    return root;
                }
                else if (root.val < low)
                {
                    return root.right;
                }
                else
                {
                    return root.left;
                }
            }
        }
    }
}
