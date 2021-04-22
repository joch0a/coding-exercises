using InterviewPreparation.Exercises;

namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class LinkedListCycle
    {
        public bool HasCycle(ListNode head)
        {
            if (head == null)
            {
                return false;
            }

            var fast = head;
            var slow = head;

            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;

                if (fast == slow)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
