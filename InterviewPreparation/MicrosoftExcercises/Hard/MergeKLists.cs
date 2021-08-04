using InterviewPreparation.Exercises;

namespace InterviewPreparation.MicrosoftExcercises.Hard
{
    class MergeKLists
    {
        public ListNode Solve(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
            {
                return null;
            }
            return Solve(lists, 0, lists.Length - 1);
        }
        private ListNode Solve(ListNode[] lists, int left, int right)
        {
            if (left == right)
            {
                return lists[left];
            }
            var mid = left + (right - left) / 2;
            var leftPartition = Solve(lists, left, mid);
            var rightPartition = Solve(lists, mid + 1, right);
            return Merge(leftPartition, rightPartition);
        }
        private ListNode Merge(ListNode left, ListNode right)
        {
            var dummy = new ListNode();
            var current = dummy;
            var currentLeft = left;
            var currentRight = right;
            while (currentLeft != null && currentRight != null)
            {
                if (currentLeft.val < currentRight.val)
                {
                    current.next = currentLeft;
                    currentLeft = currentLeft.next;
                }
                else
                {
                    current.next = currentRight;
                    currentRight = currentRight.next;
                }
                current = current.next;
            }
            while (currentLeft != null)
            {
                current.next = currentLeft;
                currentLeft = currentLeft.next;
                current = current.next;
            }
            while (currentRight != null)
            {
                current.next = currentRight;
                currentRight = currentRight.next;
                current = current.next;
            }
            return dummy.next;
        }
    }
}
