using InterviewPreparation.Exercises;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class PartitionList
    {
        public ListNode Partition(ListNode head, int x)
        {
            var dummyLesser = new ListNode();
            var dummyGreaterOrEqual = new ListNode();

            var currentLesser = dummyLesser;
            var currentGreaterOrEqual = dummyGreaterOrEqual;

            var current = head;

            while (current != null)
            {
                if (current.val < x)
                {
                    currentLesser.next = current;
                    currentLesser = currentLesser.next;
                }
                else
                {
                    currentGreaterOrEqual.next = current;
                    currentGreaterOrEqual = currentGreaterOrEqual.next;
                }

                current = current.next;
            }
            currentGreaterOrEqual.next = null;

            currentLesser.next = dummyGreaterOrEqual.next;

            return dummyLesser.next;
        }
    }
}
