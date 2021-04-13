using InterviewPreparation.Exercises;

namespace InterviewPreparation.CommonExercises.Easy_List
{
    class RemoveNTHElement
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode dummy = new ListNode(0);
            ListNode first = dummy;
            ListNode second = dummy;

            dummy.next = head;

            for (int i = 1; i <= n + 1; i++)
            {
                first = first.next;
            }
            
            while (first != null)
            {
                first = first.next;
                second = second.next;
            }
            
            second.next = second.next.next;
            
            return dummy.next;
        }
    }
}
