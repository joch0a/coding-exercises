using InterviewPreparation.Exercises;

namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class IsSubtree
    {
        public bool Solve(TreeNode s, TreeNode t)
        {
            if (s == null && t == null) return true;

            if (s == null || t == null) return false;

            return Traverse(s, t) || Solve(s.left, t) || Solve(s.right, t);
        }

        public bool Traverse(TreeNode s, TreeNode t)
        {
            if (s == null && t == null) return true;

            if (s == null || t == null) return false;

            return s.val == t.val && Traverse(s.left, t.left) && Traverse(s.right, t.right);
        }
    }
}
