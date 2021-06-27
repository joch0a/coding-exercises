using InterviewPreparation.Exercises;
using System;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class DistribuiteCoins
    {
        public int Solve(TreeNode root)
        {
            var moves = 0;

            DFS(root, ref moves);

            return moves;
        }

        public int DFS(TreeNode root, ref int moves)
        {
            if (root == null)
            {
                return 0;
            }

            var leftOverload = DFS(root.left, ref moves);
            var rightOverload = DFS(root.right, ref moves);

            moves += Math.Abs(leftOverload) + Math.Abs(rightOverload);

            return leftOverload + rightOverload + root.val - 1;
        }
    }
}
