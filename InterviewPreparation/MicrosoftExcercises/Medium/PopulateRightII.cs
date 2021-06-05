namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class PopulateRightII
    {
        public Node Connect(Node root)
        {
            if (root == null)
            {
                return null;
            }

            var actual = root;

            while (actual != null)
            {
                var nextLevel = actual.left ?? actual.right;

                while (actual != null)
                {
                    Node aux = actual;
                    Node next;

                    do
                    {
                        aux = aux.next;
                        next = aux?.left ?? aux?.right;
                    } while (aux != null && next != null);

                    if (actual.left != null && actual.right != null)
                    {
                        actual.left.next = actual.right;
                        actual.right.next = next;
                    }
                    else if (actual.left != null)
                    {
                        actual.left.next = next;
                    }
                    else if (actual.right != null)
                    {
                        actual.right.next = next;
                    }

                    actual = actual.next;
                }

                actual = nextLevel;
                nextLevel = nextLevel?.left ?? nextLevel?.right;
            }

            return root;
        }
    }
}
