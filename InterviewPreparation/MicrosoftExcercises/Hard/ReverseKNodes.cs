using InterviewPreparation.Exercises;

namespace InterviewPreparation.MicrosoftExcercises.Hard
{
    class ReverseKNodes
    {
        public ListNode ReverseKNodes(ListNode head, int k)
        {
            if (k < 1)
            {
                return head;
            }
            var fast = head;
            var slow = head;

            ListNode dummy = new ListNode(0);
            ListNode lastGroup = dummy;

            while (fast != null)
            {
                int i = 1;
                // This runner verifies if there is K remaining nodes
                while (fast != null && i <= k)
                {
                    fast = fast.next;
                    i++;
                }

                if (i - 1 == k) // If there are K node remaining 
                {
                    i = 0;
                    var first = slow;
                    ListNode prev = null;
                    while (i < k)
                    {
                        var tmp = slow.next;

                        slow.next = prev;
                        prev = slow;

                        slow = tmp;
                        i++;
                    }

                    lastGroup.next = prev;
                    lastGroup = first;
                }
                else //  If there are K node remaining 
                {
                    lastGroup.next = slow;
                }
            }

            return dummy.next;
        }
    }
}
