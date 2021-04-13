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
    }
}
