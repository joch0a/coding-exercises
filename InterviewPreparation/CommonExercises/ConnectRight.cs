using System.Collections.Generic;

namespace InterviewPreparation.Exercises
{
    public class ConnectRight
    {
        public Node Connect(Node root)
        {
            var queue = new Queue<Node>();

            queue.Enqueue(root);

            var levelSize = queue.Count;

            while (queue.Count > 0)
            {
                while (levelSize > 0)
                {
                    var actual = queue.Dequeue();

                    if (actual.left != null)
                    {
                        queue.Enqueue(actual.left);
                    }
                    if (actual.right != null)
                    {
                        queue.Enqueue(actual.right);
                    }

                    levelSize--;

                    if (levelSize > 0)
                    {
                        actual.next = queue.Peek();
                    }
                }

                levelSize = queue.Count;
            }

            return root;
        }

        public Node Connect2(Node root)
        {
            if (root == null)
            {
                return root;
            }

            var current = root;

            while (current != null)
            {
                var nextLevel = current.left;

                while (current != null)
                {
                    if (current.left != null)
                    {
                        current.left.next = current.right;
                    }

                    if (current.right != null && current.next != null)
                    {
                        current.right.next = current.next.left;
                    }

                    current = current.next;
                }

                current = nextLevel;
            }

            return root;
        }
    }
}
