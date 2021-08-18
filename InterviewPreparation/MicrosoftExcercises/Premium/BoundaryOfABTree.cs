using InterviewPreparation.Exercises;
using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Premium
{
    class BoundaryOfABTree
    {
        public IList<int> BoundaryOfBinaryTree(TreeNode root)
        {
            var boundary = new List<int>();

            if (root == null)
            {
                return boundary;
            }

            boundary.Add(root.val);

            AddLeft(root.left, boundary);

            if (root.left != null || root.right != null)
            {
                AddLeaves(root, boundary);
            }

            AddRight(root.right, boundary);

            return boundary;
        }

        //preorder
        private void AddLeft(TreeNode root, IList<int> boundary)
        {
            if (root != null && (root.left != null || root.right != null))
            {
                boundary.Add(root.val);


                if (root.left != null)
                {
                    AddLeft(root.left, boundary);
                }
                else
                {
                    AddLeft(root.right, boundary);
                }
            }
        }

        //inorder
        private void AddLeaves(TreeNode root, IList<int> boundary)
        {
            if (root != null)
            {
                AddLeaves(root.left, boundary);

                if (root.left == null && root.right == null)
                {
                    boundary.Add(root.val);
                }

                AddLeaves(root.right, boundary);
            }
        }

        //postorder
        private void AddRight(TreeNode root, IList<int> boundary)
        {
            if (root != null && (root.left != null || root.right != null))
            {
                if (root.right != null)
                {
                    AddRight(root.right, boundary);
                }
                else
                {
                    AddRight(root.left, boundary);
                }

                boundary.Add(root.val);
            }
        }
    }
}
