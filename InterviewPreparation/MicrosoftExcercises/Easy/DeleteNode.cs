using InterviewPreparation.Exercises;

namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class DeleteNode
    {
        public void Solve(ListNode node)
        {
            var actual = node;
            ListNode prev = null;

            while (actual != null && actual.next != null)
            {
                actual.val = actual.next.val;

                prev = actual;
                actual = actual.next;
            }

            prev.next = null;
        }
    }
}
