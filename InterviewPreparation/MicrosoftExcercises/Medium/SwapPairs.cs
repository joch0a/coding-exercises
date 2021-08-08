using InterviewPreparation.Exercises;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class SwapPairs
    {
        public ListNode Solve(ListNode head)
        {
            if (head == null)
            {
                return head;
            }

            var slow = head;
            var fast = head.next;

            while (fast != null)
            {
                var tmp = fast.val;
                fast.val = slow.val;
                slow.val = tmp;

                slow = fast.next;
                fast = fast?.next?.next;
            }

            return head;
        }

        public ListNode Solve2(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            var dummy = new ListNode();
            var last = dummy;
            ListNode prev = null;
            var current = head;
            var index = 1;

            dummy.next = head;

            while (current != null)
            {
                if (index % 2 == 0)
                {
                    var tmp = current.next;

                    current.next = prev;
                    prev.next = tmp;
                    last.next = current;
                    last = prev;

                    current = tmp;
                }
                else
                {
                    prev = current;
                    current = current.next;
                }

                index++;
            }

            return dummy.next;
        }
    }
}
