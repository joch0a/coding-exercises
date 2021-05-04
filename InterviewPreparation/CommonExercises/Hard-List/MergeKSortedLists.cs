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
    }
}
