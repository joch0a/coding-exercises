using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class CopyListWithRandomPointer
    {
        //O(n) space
        public Node CopyRandomList(Node head)
        {
            if (head == null)
            {
                return null;
            }

            var dictionary = new Dictionary<Node, Node>();

            var pointer = head;

            while (pointer != null)
            {
                dictionary.Add(pointer, new Node(pointer.val));
                pointer = pointer.next;
            }

            pointer = head;

            while (pointer != null)
            {
                var actual = dictionary[pointer];

                actual.next = pointer.next == null ? null : dictionary[pointer.next];
                actual.random = pointer.random == null ? null : dictionary[pointer.random];

                pointer = pointer.next;
            }

            return dictionary[head];
        }
        //O(1) space
        public Node CopyRandomListImproved(Node head)
        {
            if (head == null)
            {
                return null;
            }
            var pointer = head;

            while (pointer != null)
            {
                var temp = pointer.next;

                pointer.next = new Node(pointer.val);
                pointer.next.next = temp;
                pointer = temp;
            }

            pointer = head;

            while (pointer != null)
            {
                pointer.next.random = pointer.random?.next;
                pointer = pointer.next.next;
            }

            var original = head;
            var clone = head.next;
            var pointerO = original;
            var pointerC = clone;


            while (pointerO != null)
            {
                pointerO.next = pointerO.next?.next;
                pointerC.next = pointerC.next?.next;
                pointerO = pointerO.next;
                pointerC = pointerC.next;
            }

            return clone;
        }
    }
}
