using System.Collections.Generic;

namespace InterviewPreparation
{
    public class Node
    {
        public int data;
        public Node left;
        public Node right;
        Node(int data)
        {
            this.data = data;
            left = null;
            right = null;
        }
    }

    public class KthLargestInBST
    {
        public int kthLargest(Node root, int K)
        {
            IList<int> inorder = new List<int>();

            if (root != null)
            {
                Stack<Node> stack = new Stack<Node>();
                Node curr = root;

                while (curr != null || stack.Count > 0)
                {
                    while (curr != null)
                    {
                        stack.Push(curr);

                        curr = curr.left;
                    }

                    curr = stack.Pop();

                    inorder.Add(curr.data);

                    curr = curr.right;
                }
            }

            return inorder[inorder.Count - K];
        }
    }
}
