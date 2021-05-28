using InterviewPreparation.Exercises;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class RotateList
    {
        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null)
            {
                return null;
            }

            var fast = head;
            var length = 1;

            while (fast.next != null)
            {
                fast = fast.next;
                length++;
            }

            k = k % length;

            if (k == 0)
            {
                return head;
            }

            fast.next = head;
            ListNode prev = null;
            var newHead = head;
            var i = 1;
            var lastIndex = length - k + 1;

            while (i < lastIndex)
            {
                prev = newHead;
                newHead = newHead.next;
                i++;
            }

            prev.next = null;

            return newHead;
        }
    }
}
