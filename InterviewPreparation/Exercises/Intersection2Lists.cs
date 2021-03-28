using System.Collections.Generic;

namespace InterviewPreparation.Exercises
{
    public class Intersection2Lists
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            var currentA = headA;
            var currentB = headB;
            var visited = new HashSet<ListNode>();

            while (currentA != null && currentB != null)
            {
                if (visited.Contains(currentA))
                {
                    return currentA;
                }

                visited.Add(currentA);

                if (visited.Contains(currentB))
                {
                    return currentB;
                }

                visited.Add(currentB);

                currentA = currentA.next;
                currentB = currentB.next;
            }

            while (currentA != null)
            {
                if (visited.Contains(currentA))
                {
                    return currentA;
                }

                visited.Add(currentA);

                currentA = currentA.next;
            }

            while (currentB != null)
            {
                if (visited.Contains(currentB))
                {
                    return currentB;
                }

                visited.Add(currentB);

                currentB = currentB.next;
            }

            return null;
        }
    }
}
