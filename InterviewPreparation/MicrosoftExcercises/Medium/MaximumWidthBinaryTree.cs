using InterviewPreparation.Exercises;
using System;
using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class MaximumWidthBinaryTree
    {
        public int WidthOfBinaryTree(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            var max = 1;
            var queue = new Queue<LabeledNode>();
            queue.Enqueue(new LabeledNode(root, 1));
            while (queue.Count > 0)
            {
                var queueSize = queue.Count;
                LabeledNode firstNode = null;
                while (queueSize > 0)
                {
                    var actual = queue.Dequeue();
                    if (actual.Node.left != null)
                    {
                        queue.Enqueue(new LabeledNode(actual.Node.left, actual.Position * 2));
                    }
                    if (actual.Node.right != null)
                    {
                        queue.Enqueue(new LabeledNode(actual.Node.right, (actual.Position * 2) + 1));
                    }
                    if (firstNode == null)
                    {
                        firstNode = actual;
                    }
                    else if (queueSize == 1)
                    {
                        max = Math.Max(max, actual.Position - firstNode.Position + 1);
                    }
                    queueSize--;
                }
            }
        
            return max;
        }

        public class LabeledNode
        {
            public TreeNode Node { get; set; }
            public int Position { get; set; }
            public LabeledNode(TreeNode node, int position)
            {
                Node = node;
                Position = position;
            }
        }
    }
}
