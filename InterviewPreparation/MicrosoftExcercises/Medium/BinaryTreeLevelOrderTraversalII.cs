using InterviewPreparation.Exercises;
using System.Collections.Generic;
using System.Linq;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class BinaryTreeLevelOrderTraversalII
    {
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            var result = new LinkedList<IList<int>>();

            if (root == null)
            {
                return result.ToList();
            }

            var currentLevel = new List<int>();
            var queue = new Queue<TreeNode>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var queueSize = queue.Count;

                while (queueSize > 0)
                {
                    var actual = queue.Dequeue();

                    currentLevel.Add(actual.val);

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

                result.AddFirst(currentLevel);

                currentLevel = new List<int>();
            }

            return result.ToList();
        }
    }
}
