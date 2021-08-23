using InterviewPreparation.Exercises;
using System.Collections.Generic;
using System.Linq;

namespace InterviewPreparation.MicrosoftExcercises.Premium
{
    class VerticalOrder
    {
        public IList<IList<int>> Solve(TreeNode root)
        {
            if (root == null)
            {
                return new List<IList<int>>();
            }

            var verticalOrder = new Dictionary<int, IList<int>>();

            BuildVerticalOrder(root, verticalOrder);

            return verticalOrder.OrderBy(tuple => tuple.Key)
                .Select(tuple => tuple.Value)
                .ToList();
        }

        private void BuildVerticalOrder(TreeNode root, Dictionary<int, IList<int>> dict)
        {
            var queue = new Queue<(TreeNode, int)>();

            queue.Enqueue((root, 0));

            while (queue.Count > 0)
            {
                var (actual, position) = queue.Dequeue();

                if (!dict.ContainsKey(position))
                {
                    dict.Add(position, new List<int>());
                }

                dict[position].Add(actual.val);

                if (actual.left != null)
                {
                    queue.Enqueue((actual.left, position - 1));
                }

                if (actual.right != null)
                {
                    queue.Enqueue((actual.right, position + 1));
                }
            }
        }
    }
}
}
