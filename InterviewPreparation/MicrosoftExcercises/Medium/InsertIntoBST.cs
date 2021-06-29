using InterviewPreparation.Exercises;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class InsertIntoBST
    {
        public TreeNode Solve(TreeNode root, int val)
        {
            if (root == null)
            {
                return new TreeNode(val);
            }

            TreeNode prev = null;
            var current = root;
            bool isLeft = false;

            while (current != null)
            {
                prev = current;

                if (current.val > val)
                {
                    current = current.left;
                    isLeft = true;
                }
                else
                {
                    current = current.right;
                    isLeft = false;
                }
            }

            if (isLeft)
            {
                prev.left = new TreeNode(val);
            }
            else
            {
                prev.right = new TreeNode(val);
            }

            return root;
        }
    }
}
