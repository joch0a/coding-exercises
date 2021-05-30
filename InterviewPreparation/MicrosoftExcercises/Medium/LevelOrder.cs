using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class LevelOrder
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            if (root == null)
            {
                return new List<IList<int>>(); ;
            }

            var result = new List<IList<int>>();
            var queue = new Queue<TreeNode>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var queueSize = queue.Count;
                var actualLevel = new List<int>();

                while (queueSize > 0)
                {
                    var actual = queue.Dequeue();

                    actualLevel.Add(actual.val);

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

                result.Add(actualLevel);
            }

            return result;
        }
    }
}
