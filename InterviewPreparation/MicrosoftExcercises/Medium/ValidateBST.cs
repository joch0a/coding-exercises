using InterviewPreparation.Exercises;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class ValidateBST
    {
        public bool IsValidBST(TreeNode root)
        {
            return IsValidBST(root, null, null);
        }

        private bool IsValidBST(TreeNode root, int? min, int? max)
        {
            if (root == null)
            {
                return true;
            }

            if ((min != null && root.val <= min) ||
                (max != null && root.val >= max))
            {
                return false;
            }

            return IsValidBST(root.left, min, root.val) && IsValidBST(root.right, root.val, max);
        }
    }
}
