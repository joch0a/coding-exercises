using InterviewPreparation.Exercises;
using System.Collections.Generic;
using System.Linq;

namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class MinDepth
    {
        public int Solve(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            var queue = new Queue<TreeNode>();
            var level = 0;

            queue.Enqueue(root);

            while (queue.Any())
            {
                var queueSize = queue.Count;
                level++;

                while (queueSize > 0)
                {
                    var actual = queue.Dequeue();

                    if (actual.left == null && actual.right == null)
                    {
                        return level;
                    }

                    if (actual.left != null)
                    {
                        queue.Enqueue(actual.left);
                    }

                    if (actual.right != null)
                    {
                        queue.Enqueue(actual.right);
                    }

                    queueSize--;
                }
            }

            return level;
        }
    }
}
