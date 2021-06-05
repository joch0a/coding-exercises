using InterviewPreparation.Exercises;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class ReorderList
    {
        public void Solve(ListNode head)
        {
            var slow = head;
            var fast = head;
            var dummy = new ListNode();
            var actual = dummy;

            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }

            var aux = slow;
            ListNode prev = null;

            while (aux != null)
            {
                var tmp = aux.next;

                aux.next = prev;
                prev = aux;

                aux = tmp;
            }

            var start = head;

            while (start != slow)
            {
                var tmp1 = start?.next;
                var tmp2 = prev?.next;

                if (start != null)
                {
                    actual.next = start;
                    actual = actual.next;
                }

                if (prev != null)
                {
                    actual.next = prev;
                    actual = actual.next;
                }

                start = tmp1;
                prev = tmp2;
            }

            head = dummy.next;
        }
    }
}
