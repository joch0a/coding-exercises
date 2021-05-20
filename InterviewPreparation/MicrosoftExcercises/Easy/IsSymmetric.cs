using InterviewPreparation.Exercises;
using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class IsSymmetric
    {
        public bool Solve(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            var queue = new Queue<TreeNode>();

            queue.Enqueue(root);
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var n1 = queue.Dequeue();
                var n2 = queue.Dequeue();

                if (n1 == null && n2 == null)
                {
                    continue;
                }

                if ((n1 == null && n2 != null) ||
                   (n1 != null && n2 == null) ||
                   n1.val != n2.val)
                {
                    return false;
                }

                queue.Enqueue(n1.left);
                queue.Enqueue(n2.right);
                queue.Enqueue(n1.right);
                queue.Enqueue(n2.left);
            }

            return true;
        }
    }
}
