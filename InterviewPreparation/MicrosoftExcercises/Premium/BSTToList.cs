namespace InterviewPreparation.MicrosoftExcercises.Premium
{
    class BSTToList
    {
        private Node last;
        private Node first;

        public Node TreeToDoublyList(Node root)
        {
            if (root == null)
            {
                return null;
            }

            buildInorder(root);

            first.left = last;
            last.right = first;

            return first;
        }

        private void buildInorder(Node root)
        {
            if (root == null)
            {
                return;
            }

            buildInorder(root.left);

            if (last == null)
            {
                first = root;
            }
            else
            {
                last.right = root;
                root.left = last;
            }

            last = root;

            buildInorder(root.right);
        }
    }
}
