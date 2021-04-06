using System.Collections.Generic;

namespace InterviewPreparation.Exercises
{
    public class ZigzagOrderTrasversal
    {
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            var zigzag = new List<IList<int>>();

            if (root == null)
            {
                return zigzag;
            }

            var stack = new Stack<TreeNode>();
            var stackAux = new Stack<TreeNode>();
            var isRight = true;
            TreeNode actual;

            stack.Push(root);

            do
            {
                var actualLevel = new List<int>();

                while (stack.Count > 0)
                {
                    actual = stack.Pop();

                    actualLevel.Add(actual.val);

                    if (isRight)
                    {
                        if (actual.left != null)
                        {
                            stackAux.Push(actual.left);
                        }

                        if (actual.right != null)
                        {
                            stackAux.Push(actual.right);
                        }
                    }
                    else
                    {
                        if (actual.right != null)
                        {
                            stackAux.Push(actual.right);
                        }

                        if (actual.left != null)
                        {
                            stackAux.Push(actual.left);
                        }
                    }
                }

                zigzag.Add(actualLevel);
                stack = stackAux;
                stackAux = new Stack<TreeNode>();
                isRight = !isRight;

            } while (stack.Count > 0);

            return zigzag;
        }
    }
}
