using InterviewPreparation.Exercises;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class SortList
    {
        public class Solution
        {
            public ListNode SortList(ListNode head)
            {
                if (head == null || head.next == null)
                {
                    return head;
                }

                var mid = GetMid(head);
                var left = SortList(head);
                var right = SortList(mid);

                return Merge(left, right);
            }

            private ListNode Merge(ListNode left, ListNode right)
            {
                var dummy = new ListNode();
                var p1 = left;
                var p2 = right;
                var current = dummy;

                while (p1 != null && p2 != null)
                {
                    if (p1.val < p2.val)
                    {
                        current.next = p1;

                        p1 = p1.next;
                    }
                    else
                    {
                        current.next = p2;

                        p2 = p2.next;
                    }

                    current = current.next;
                }

                if (p1 != null)
                {
                    current.next = p1;
                }

                if (p2 != null)
                {
                    current.next = p2;
                }

                return dummy.next;
            }

            private ListNode GetMid(ListNode head)
            {
                ListNode slow = null;
                var fast = head;

                while (fast != null && fast.next != null)
                {
                    slow = slow == null ? fast : slow.next;
                    fast = fast.next.next;
                }

                var mid = slow.next;

                slow.next = null;

                return mid;
            }
        }
    }
}
