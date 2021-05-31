using InterviewPreparation.Exercises;
using System.Collections.Generic;
using System.Linq;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    public class BSTIterator
    {

        private int Index;
        private IList<TreeNode> Iterator;

        public BSTIterator(TreeNode root)
        {
            Index = 0;
            Iterator = new List<TreeNode>();

            var actual = root;
            var stack = new Stack<TreeNode>();

            while (actual != null || stack.Count > 0)
            {
                while (actual != null)
                {
                    stack.Push(actual);
                    actual = actual.left;
                }

                actual = stack.Pop();

                Iterator.Add(actual);

                actual = actual.right;
            }
        }

        public int Next()
        {
            return Iterator.ElementAt(Index++).val;
        }

        public bool HasNext()
        {
            return Index < Iterator.Count;
        }
    }
}
