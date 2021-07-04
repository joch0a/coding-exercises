using InterviewPreparation.Exercises;
using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class SolveSortedListToBST
    {
        public TreeNode SortedListToBST(ListNode head)
        {
            var list = new List<ListNode>();

            var current = head;

            while (current != null)
            {
                list.Add(current);

                current = current.next;
            }

            var array = list.ToArray();

            var BST = CreateBST(array, 0, array.Length - 1);

            return BST;
        }

        public TreeNode CreateBST(ListNode[] array, int left, int right)
        {
            if (left > right)
            {
                return null;
            }

            var currentElement = left + (right - left) / 2;

            var newNode = new TreeNode(array[currentElement].val);

            newNode.left = CreateBST(array, left, currentElement - 1);
            newNode.right = CreateBST(array, currentElement + 1, right);

            return newNode;
        }
    }
}
