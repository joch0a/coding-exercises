using System.Collections.Generic;

namespace InterviewPreparation.Exercises
{
    public class InvertBinaryTree
    {

        //Recursive way
        public TreeNode InvertTree(TreeNode root)
        {
            if (root != null)
            {
                InvertTree(root.left);
                InvertTree(root.right);

                var aux = root.left;
                root.left = root.right;
                root.right = aux;
            }

            return root;
        }

        //BFS like
        public TreeNode InvertTreeBFS(TreeNode root)
        {
            if (root == null)
            {
                return root;
            }

            var queue = new Queue<TreeNode>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current.left != null)
                {
                    queue.Enqueue(current.left);
                }

                if (current.right != null)
                {
                    queue.Enqueue(current.right);
                }

                var aux = current.left;
                current.left = current.right;
                current.right = aux;
            }

            return root;
        }

        //Preorder 

        public TreeNode InvertTreePreorder(TreeNode root)
        {
            if (root == null)
            {
                return root;
            }

            var stack = new Stack<TreeNode>();

            stack.Push(root);

            while (stack.Count > 0)
            {
                var current = stack.Pop();

                var aux = current.left;
                current.left = current.right;
                current.right = aux;

                if (current.left != null)
                {
                    stack.Push(current.left);
                }

                if (current.right != null)
                {
                    stack.Push(current.right);
                }
            }

            return root;
        }
    }
}
