using InterviewPreparation.Exercises;
using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class InorderTraversal
    {
        public IList<int> Solve(TreeNode root)
        {
            var stack = new Stack<TreeNode>();
            var list = new List<int>();
            var current = root;

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }

                current = stack.Pop();

                list.Add(current.val);

                current = current.right;
            }

            return list;
        }
    }
}
