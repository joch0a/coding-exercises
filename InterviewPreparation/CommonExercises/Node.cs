namespace InterviewPreparation.Exercises
{
    public class Node
    {
        public int data;
        public Node left;
        public Node right;
        public Node next;
        private object val;

        public Node(object val)
        {
            this.val = val;
        }

        Node(int data)
        {
            this.data = data;
            left = null;
            right = null;
        }
    }
}
