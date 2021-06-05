using InterviewPreparation.Exercises;
using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class AllNodesDistanceK
    {
        public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
        {
            var result = new List<int>();

            if (k == 0)
            {
                result.Add(target.val);

                return result;
            }

            var queue = new Queue<TreeNode>();
            var parents = new Dictionary<TreeNode, TreeNode>();

            queue.Enqueue(root);
            parents.Add(root, null);

            while (queue.Count > 0)
            {
                var queueSize = queue.Count;

                while (queueSize > 0)
                {
                    var actual = queue.Dequeue();

                    if (actual.left != null)
                    {
                        parents.Add(actual.left, actual);
                        queue.Enqueue(actual.left);
                    }

                    if (actual.right != null)
                    {
                        parents.Add(actual.right, actual);
                        queue.Enqueue(actual.right);
                    }

                    queueSize--;
                }
            }

            var visited = new HashSet<TreeNode>();
            var level = 0;

            queue.Enqueue(target);

            while (queue.Count > 0 && level <= k)
            {
                var queueSize = queue.Count;

                while (queueSize > 0)
                {
                    var actual = queue.Dequeue();
                    visited.Add(actual);

                    if (level == k)
                    {
                        result.Add(actual.val);
                    }

                    if (actual.left != null && !visited.Contains(actual.left))
                    {
                        queue.Enqueue(actual.left);
                    }

                    if (actual.right != null && !visited.Contains(actual.right))
                    {
                        queue.Enqueue(actual.right);
                    }

                    if (parents[actual] != null && !visited.Contains(parents[actual]))
                    {
                        queue.Enqueue(parents[actual]);
                    }

                    queueSize--;
                }

                level++;
            }

            return result;
        }
    }
}
