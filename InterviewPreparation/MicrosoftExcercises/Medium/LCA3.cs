using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class LCA3
    {
        public Node LowestCommonAncestor(Node p, Node q)
        {
            var visited = new HashSet<Node>();

            var current = p;

            while (current != null)
            {
                visited.Add(current);

                current = current.parent;
            }

            current = q;

            while (current != null)
            {
                if (visited.Contains(current))
                {
                    return current;
                }

                current = current.parent;
            }

            return null;
        }
    }
}
