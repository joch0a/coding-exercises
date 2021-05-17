using InterviewPreparation.Exercises;
using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class BinaryTreePath
    {
        public IList<string> result;

        public IList<string> BinaryTreePaths(TreeNode root)
        {
            result = new List<string>();
            BinaryTreePathsAux(root, "");
            return result;
        }

        private void BinaryTreePathsAux(TreeNode root, string path)
        {
            if (root != null)
            {
                if (root.left == null && root.right == null)
                {
                    path += $"{root.val}";
                    result.Add(path);
                }
                path += $"{root.val}->";
                if (root.left != null)
                {
                    BinaryTreePathsAux(root.left, path);
                }
                if (root.right != null)
                {
                    BinaryTreePathsAux(root.right, path);
                }
            }
        }
    }
}
