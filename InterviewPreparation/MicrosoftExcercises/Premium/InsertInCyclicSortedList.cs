namespace InterviewPreparation.MicrosoftExcercises.Premium
{
    class InsertInCyclicSortedList
    {
        public Node Insert(Node head, int val)
        {
            if (head == null)
            {
                var newNode = new Node(val);
                newNode.next = newNode;

                return newNode;
            }

            Node prev = head;
            Node current = head.next;
            bool insert = false;

            do
            {
                if (prev.val <= val && val <= current.val)
                {
                    insert = true;
                }
                else if (prev.val > current.val)
                {
                    if (val >= prev.val || val <= current.val)
                    {
                        insert = true;
                    }
                }

                if (insert)
                {
                    var newNode = new Node(val, current);

                    prev.next = newNode;

                    return head;
                }

                prev = current;
                current = current.next;

            } while (prev != head);

            prev.next = new Node(val, current);

            return head;
        }
    }
}
