using InterviewPreparation.Exercises;

namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class DeleteDuplicates
    {
        public ListNode Solve(ListNode head)
        {
            var actual = head;
            while (actual != null && actual.next != null)
            {
                if (actual.val == actual.next.val)
                {
                    actual.next = actual.next.next;
                }
                else
                {
                    actual = actual.next;
                }
            }
            return head;
        }
    }
}
