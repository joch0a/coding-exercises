using InterviewPreparation.Exercises;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class SwappingNodesInALinkedList
    {
        public ListNode SwapNodes(ListNode head, int k)
        {
            if (head == null)
            {
                return head;
            }

            var index = 1;
            var fast = head;

            while (index < k)
            {
                fast = fast.next;
                index++;
            }

            var firstSwap = fast;
            fast = fast.next;
            var slow = head;

            while (fast != null)
            {
                fast = fast.next;
                slow = slow.next;
            }

            var aux = slow.val;
            slow.val = firstSwap.val;
            firstSwap.val = aux;

            return head;
        }
    }
}
