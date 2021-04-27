using InterviewPreparation.Exercises;

namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class LowestCommonAncestor
    {
        public TreeNode Solve(TreeNode root, TreeNode p, TreeNode q)
        {
            var p1 = root;

            while (p1 != null)
            {
                if (p1.val == p.val)
                {
                    return p;
                }

                if (p1.val == q.val)
                {
                    return q;
                }

                if ((p.val > p1.val && q.val < p1.val) || (q.val > p1.val && p.val < p1.val))
                {
                    return p1;
                }

                if (p.val > p1.val)
                {
                    p1 = p1.right;
                }
                else
                {
                    p1 = p1.left;
                }
            }

            return p1;
        }
    }
}
