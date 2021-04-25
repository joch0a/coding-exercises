using InterviewPreparation.Exercises;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class ReverseLinkedListII
    {
        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            if (left == right)
            {
                return head;
            }

            var fast = head;
            var slow = head;

            var diff = right - left;

            for (int i = 0; i <= diff; i++)
            {
                fast = fast?.next;
            }

            ListNode globalPrev = null;

            for (int i = 1; i < left; i++)
            {
                globalPrev = slow;
                fast = fast?.next;
                slow = slow?.next;
            }

            ListNode prev = null;
            ListNode first = null;

            while (slow != fast)
            {
                var tmp = slow.next;

                slow.next = prev;
                prev = slow;

                if (first == null)
                {
                    first = slow;
                }

                slow = tmp;
            }

            first.next = fast;

            if (globalPrev == null)
            {
                return prev;
            }
            else
            {
                globalPrev.next = prev;
            }

            return head;
        }
    }
}
