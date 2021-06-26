using InterviewPreparation.Exercises;
using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class BuildTreePostorderInorder
    {
        private Dictionary<int, int> inorderPositions;
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            int postOrderPosition = postorder.Length - 1;
            inorderPositions = new Dictionary<int, int>();
            for (int i = 0; i < inorder.Length; i++)
            {
                inorderPositions.Add(inorder[i], i);
            }
            return BuildTreeAux(inorder, postorder, 0, postorder.Length - 1, ref postOrderPosition);
        }
        private TreeNode BuildTreeAux(int[] inorder, int[] postorder, int left, int right, ref int postOrderPosition)
        {
            if (left > right)
            {
                return null;
            }

            int rootValue = postorder[postOrderPosition];
            
            postOrderPosition--;
            
            var root = new TreeNode(rootValue);

            root.right = BuildTreeAux(inorder, postorder, inorderPositions[rootValue] + 1, right, ref postOrderPosition);
            root.left = BuildTreeAux(inorder, postorder, left, inorderPositions[rootValue] - 1, ref postOrderPosition);
            return root;
        }
    }
}
