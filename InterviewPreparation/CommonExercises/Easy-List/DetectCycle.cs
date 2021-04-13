using InterviewPreparation.Exercises;

namespace InterviewPreparation.CommonExercises.Easy_List
{
    class DetectCycle
    {
        public bool HasCycle(ListNode head)
        {
            if (head == null)
            {
                return false;
            }

            var slow = head;
            ListNode fast = head.next;

            while (fast != null && fast.next != null)
            {
                if (fast == slow)
                {
                    return true;
                }

                slow = slow.next;
                fast = fast.next.next;
            }

            return false;
        }

        public ListNode DetectCycleII(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            var fast = head;
            var slow = head;

            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;

                if (fast == slow)
                {
                    break;
                }
            }

            if (fast == null || fast.next == null)
            {
                return null;
            }

            slow = head;

            while (fast != slow)
            {
                fast = fast.next;
                slow = slow.next;
            }

            return fast;
        }
    }
}
