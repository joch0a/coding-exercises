using System;
using System.Collections.Generic;

namespace InterviewPreparation.Exercises
{
    class SumTwoNumbers
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode head = new ListNode();

            var s1 = GetQueue(l1);
            var s2 = GetQueue(l2);
            var carry = 0;
            var actual = head;

            head.next = actual;

            while (s1.Count > 0 || s2.Count > 0 || carry != 0)
            {
                var sum = carry;

                if (s1.Count > 0)
                {
                    sum += s1.Dequeue();
                }

                if (s2.Count > 0)
                {
                    sum += s2.Dequeue();
                }

                actual.next = new ListNode(sum % 10);
                actual = actual.next;

                carry = sum / 10;
            }

            return head.next;
        }

        private Queue<int> GetQueue(ListNode list)
        {
            var queue = new Queue<int>();
            var aux = list;

            while (aux != null)
            {
                queue.Enqueue(aux.val);
                aux = aux.next;
            }

            return queue;
        }
    }
}
