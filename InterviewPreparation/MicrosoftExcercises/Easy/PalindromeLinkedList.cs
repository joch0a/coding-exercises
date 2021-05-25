using InterviewPreparation.Exercises;

namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class PalindromeLinkedList
    {
        public bool IsPalindrome(ListNode head)
        {
            if (head == null)
            {
                return true;
            }

            var fast = head;
            var slow = head;
            ListNode prev = null;

            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;

                var tmp = slow.next;
                slow.next = prev;
                prev = slow;

                slow = tmp;
            }

            if (fast != null && fast.next == null)
            {
                slow = slow.next;
            }

            while (slow != null)
            {
                if (prev.val != slow.val)
                {
                    return false;
                }

                slow = slow.next;
                prev = prev.next;
            }

            return true;
        }
    }
}
