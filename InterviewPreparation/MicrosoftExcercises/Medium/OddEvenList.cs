using InterviewPreparation.Exercises;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class OddEvenList
    {
        public ListNode Solve(ListNode head)
        {
            var odds = new ListNode();
            var evens = new ListNode();

            var actualOdd = odds;
            var actualEven = evens;

            var current = head;
            var isOdd = true;

            while (current != null)
            {
                if (isOdd)
                {
                    actualOdd.next = current;
                    actualOdd = actualOdd.next;
                }
                else
                {
                    actualEven.next = current;
                    actualEven = actualEven.next;
                }

                isOdd = !isOdd;
                current = current.next;
            }

            actualOdd.next = evens.next;
            actualEven.next = null;

            return odds.next;
        }
    }
}
