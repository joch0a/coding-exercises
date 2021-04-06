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
    }
}
