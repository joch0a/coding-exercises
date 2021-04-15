namespace InterviewPreparation.MicrosoftExcercises
{
    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node()
        {
        }

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }
}
