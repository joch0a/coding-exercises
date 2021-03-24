namespace InterviewPreparation.Exercises
{
    public class ValidateBST
    {
        //Recursive way
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

            if ((min != null && min >= root.val) || (max != null && max <= root.val))
            {
                return false;
            }

            return IsValidBST(root.left, min, root.val) && IsValidBST(root.right, root.val, max);
        }
    }
}
