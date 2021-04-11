using InterviewPreparation.Exercises;

namespace InterviewPreparation.CommonExercises.Easy_List
{
    //https://leetcode.com/explore/interview/card/top-interview-questions-easy/93/linked-list/771/
    class MergeTwoSortedLists
    {
        public ListNode Solve(ListNode l1, ListNode l2)
        {
            if (l1 == null)
            {
                return l2;
            }

            if (l2 == null)
            {
                return l1;
            }

            var actual1 = l1;
            var actual2 = l2;
            ListNode dummy = new ListNode();
            ListNode result = dummy;


            while (actual1 != null && actual2 != null)
            {
                if (actual1.val < actual2.val)
                {
                    result.next = new ListNode(actual1.val);
                    actual1 = actual1.next;
                }
                else
                {
                    result.next = new ListNode(actual2.val);
                    actual2 = actual2.next;
                }

                result = result.next;
            }

            while (actual1 != null)
            {
                result.next = new ListNode(actual1.val);
                actual1 = actual1.next;
                result = result.next;
            }

            while (actual2 != null)
            {
                result.next = new ListNode(actual2.val);
                actual2 = actual2.next;
                result = result.next;
            }

            return dummy.next;
        }
    }
}
