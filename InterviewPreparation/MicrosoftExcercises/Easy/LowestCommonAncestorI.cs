using InterviewPreparation.Exercises;

namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class LowestCommonAncestorI
    {
        public TreeNode Solve(TreeNode root, TreeNode p, TreeNode q)
        {
            var actual = root;

            while (actual != null)
            {
                if ((actual.val >= p.val && actual.val <= q.val) ||
                  (actual.val <= p.val && actual.val >= q.val))
                {
                    return actual;
                }
                else if (actual.val > p.val && actual.val > q.val)
                {
                    actual = actual.left;
                }
                else
                {
                    actual = actual.right;
                }
            }

            return actual;
        }
    }
}
