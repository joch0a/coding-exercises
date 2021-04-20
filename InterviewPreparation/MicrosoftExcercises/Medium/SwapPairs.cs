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
    }
}
