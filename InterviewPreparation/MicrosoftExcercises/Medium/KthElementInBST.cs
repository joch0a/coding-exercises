using InterviewPreparation.Exercises;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class KthElementInBST
    {
        private int currentNumber;
        private int finalNumber;

        public int KthSmallest(TreeNode root, int k)
        {
            currentNumber = k;

            CreateInorderBSTList(root);

            return finalNumber;
        }

        public void CreateInorderBSTList(TreeNode root)
        {
            if (root != null && currentNumber != 0)
            {
                CreateInorderBSTList(root.left);
                currentNumber--;

                if (currentNumber == 0)
                {
                    finalNumber = root.val;
                }

                CreateInorderBSTList(root.right);
            }
        }
    }
}
