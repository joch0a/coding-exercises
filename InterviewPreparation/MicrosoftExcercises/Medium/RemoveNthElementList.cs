using InterviewPreparation.Exercises;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class RemoveNthElementList
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var slow = head;
            var fast = head;
            ListNode prev = null;

            for (int i = 0; i < n; i++)
            {
                fast = fast?.next;
            }

            while (fast != null)
            {
                prev = slow;
                slow = slow?.next;
                fast = fast?.next;
            }

            if (prev != null)
            {
                prev.next = slow.next;
                return head;
            }
            else
            {
                return slow?.next;
            }
        }
    }
}
