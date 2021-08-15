using InterviewPreparation.Exercises;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewPreparation.CommonExercises.Hard_List
{
    class MergeKSortedLists
    {
        //brute force approach
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length < 1)
            {
                return null;
            }

            var nodeList = new List<ListNode>();

            foreach (var node in lists)
            {
                var aux = node;

                while (aux != null)
                {
                    nodeList.Add(aux);
                    aux = aux.next;
                }
            }

            var sorted = nodeList.ToArray();

            Array.Sort(sorted, (x1, x2) => x1.val.CompareTo(x2.val));

            for (int i = 1; i < sorted.Length; i++)
            {
                sorted[i - 1].next = sorted[i];

                if (i == sorted.Length - 1)
                {
                    sorted[i].next = null;
                }
            }

            return sorted.Length >= 1 ? sorted[0] : null;
        }

        public ListNode MergeKLists2(ListNode[] lists)
        {
            return MergeKLists2(lists, 0, lists.Length - 1);
        }

        private ListNode MergeKLists2(ListNode[] lists, int left, int right)
        {
            if (left == right)
            {
                return lists[left];
            }

            if (left > right)
            {
                return null;
            }

            var mid = left + (right - left) / 2;
            var leftPartition = MergeKLists2(lists, left, mid);
            var rightPartition = MergeKLists2(lists, mid + 1, right);

            return Merge2(leftPartition, rightPartition);
        }

        private ListNode Merge2(ListNode left, ListNode right)
        {
            var dummy = new ListNode();
            var current = dummy;
            var p1 = left;
            var p2 = right;

            while (p1 != null && p2 != null)
            {
                if (p1.val <= p2.val)
                {
                    current.next = p1;
                    p1 = p1.next;
                }
                else
                {
                    current.next = p2;
                    p2 = p2.next;
                }

                current = current.next;
            }

            current.next = p1 ?? p2;

            return dummy.next;
        }
    }
}
