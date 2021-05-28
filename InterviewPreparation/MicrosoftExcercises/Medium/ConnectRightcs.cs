

using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class ConnectRightcs
    {
        //SPACE O(1) solution
        public Node Connect(Node root)
        {
            if (root == null)
            {
                return null;
            }

            var actual = root;

            while (actual.left != null)
            {
                var nextLevel = actual.left;

                while (actual != null)
                {
                    actual.left.next = actual.right;

                    if (actual.next == null)
                    {
                        actual.right.next = null;
                    }
                    else
                    {
                        actual.right.next = actual.next.left;
                    }

                    actual = actual.next;
                }

                actual = nextLevel;
            }

            return root;
        }

        //BFS QUEUE Approach
        public Node Connect2(Node root)
        {
            if (root == null)
            {
                return root;
            }

            var queue = new Queue<Node>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var queueSize = queue.Count;
                Node prev = null;

                while (queueSize > 0)
                {
                    var actual = queue.Dequeue();

                    if (prev != null)
                    {
                        prev.next = actual;
                    }

                    prev = actual;

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

            return root;
        }
    }
}
