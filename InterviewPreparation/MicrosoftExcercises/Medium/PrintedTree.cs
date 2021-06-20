using InterviewPreparation.Exercises;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class PrintedTree
    {
        public class Solution
        {
            public IList<IList<string>> PrintTree(TreeNode root)
            {
                var result = new List<IList<string>>();

                if (root == null)
                {
                    return result;
                }
                var levelOrderTrasversal = new List<IList<LabeledNode>>();
                var queue = new Queue<LabeledNode>();
                int height = 0;
                int totalColumns = 1;

                queue.Enqueue(new LabeledNode(root, null, true)); //those parameters are unnecesary

                while (queue.Count > 0)
                {
                    var queueSize = queue.Count;
                    levelOrderTrasversal.Add(queue.ToList());

                    while (queueSize > 0)
                    {
                        var current = queue.Dequeue();

                        if (current.Node.left != null)
                        {
                            queue.Enqueue(new LabeledNode(current.Node.left, current.Node, true));
                        }

                        if (current.Node.right != null)
                        {
                            queue.Enqueue(new LabeledNode(current.Node.right, current.Node, false));
                        }

                        queueSize--;
                    }
                    height++;
                    totalColumns = (int)Math.Pow(2, height) - 1;
                }

                var actualLevel = 0;
                var parentPosition = new Dictionary<TreeNode, int>();

                foreach (var level in levelOrderTrasversal)
                {
                    var printedLevel = new string[totalColumns];
                    Array.Fill(printedLevel, "");

                    foreach (var node in level)
                    {
                        if (actualLevel == 0)
                        {
                            var position = (totalColumns - 1) / 2;
                            parentPosition.Add(node.Node, position);
                            printedLevel[position] = node.Node.val.ToString();
                        }
                        else
                        {
                            var actualParentPosition = parentPosition[node.Parent];
                            int position;

                            if (node.IsLeft)
                            {
                                position = (int)(actualParentPosition - Math.Pow(2, (height - actualLevel - 1)));
                            }
                            else
                            {
                                position = (int)(actualParentPosition + Math.Pow(2, (height - actualLevel - 1)));
                            }

                            parentPosition.Add(node.Node, position);
                            printedLevel[position] = node.Node.val.ToString();
                        }
                    }

                    actualLevel++;
                    result.Add(printedLevel.ToList());
                }

                return result;
            }
        }

        public class LabeledNode
        {
            public TreeNode Node { get; set; }
            public TreeNode Parent { get; set; }
            public bool IsLeft { get; set; }

            public LabeledNode(TreeNode node, TreeNode parent, bool isLeft)
            {
                Node = node;
                Parent = parent;
                IsLeft = isLeft;
            }
        }
    }
}
