﻿using InterviewPreparation.Exercises;

namespace InterviewPreparation.CommonExercises.Easy_List
{
    class ReverseList
    {
        public ListNode Solution(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            else
            {
                var actual = Solution(head.next);
                head.next.next = head;
                head.next = null;

                return actual;
            }
        }

        public ListNode ReverseListTwoPointers(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            var slow = head;
            ListNode prev = null;

            while (slow != null)
            {
                var tmp = slow.next;
                slow.next = prev;
                prev = slow;
                slow = tmp;
            }

            return prev;
        }
    }
}
