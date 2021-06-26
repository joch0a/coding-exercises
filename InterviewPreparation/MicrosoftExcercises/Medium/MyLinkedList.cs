namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    public class MyLinkedList
    {

        private LinkedNode head;
        private int size;

        /** Initialize your data structure here. */
        public MyLinkedList()
        {
            head = new LinkedNode(0, null);
            size = 0;
        }

        /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
        public int Get(int index)
        {
            var current = head.next;
            for (int currentIndex = 0; currentIndex < index && current != null; currentIndex++)
            {
                if (currentIndex == index)
                {
                    return current.val;
                }

                current = current.next;
            }

            return current != null ? current.val : -1;
        }

        /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
        public void AddAtHead(int val)
        {
            head.next = new LinkedNode(val, head.next);

            size++;
        }

        /** Append a node of value val to the last element of the linked list. */
        public void AddAtTail(int val)
        {
            var current = head;

            while (current.next != null)
            {
                current = current.next;
            }

            current.next = new LinkedNode(val, null);

            size++;
        }

        /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
        public void AddAtIndex(int index, int val)
        {
            if (index > size)
            {
                return;
            }

            var current = head;

            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }
            current.next = new LinkedNode(val, current.next);

            size++;
        }

        /** Delete the index-th node in the linked list, if the index is valid. */
        public void DeleteAtIndex(int index)
        {
            if (index >= size)
            {
                return;
            }

            var current = head;

            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }

            current.next = current?.next?.next;

            size--;
        }
    }

    public class LinkedNode
    {
        public LinkedNode next { get; set; }

        public int val { get; set; }

        public LinkedNode(int val, LinkedNode next)
        {
            this.val = val;
            this.next = next;
        }
    }


    /**
     * Your MyLinkedList object will be instantiated and called as such:
     * MyLinkedList obj = new MyLinkedList();
     * int param_1 = obj.Get(index);
     * obj.AddAtHead(val);
     * obj.AddAtTail(val);
     * obj.AddAtIndex(index,val);
     * obj.DeleteAtIndex(index);
     */
}
