using InterviewPreparation.Exercises;
using System;

namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class BalancedHeightTree
    {
        public bool IsBalanced(TreeNode root)
        {
            return IsBalancedAux(root) != -1;
        }

        public int IsBalancedAux(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                var left = IsBalancedAux(root.left);

                if (left == -1)
                {
                    return -1;
                }

                var right = IsBalancedAux(root.right);

                if (right == -1)
                {
                    return -1;
                }

                if (Math.Abs(left - right) > 1)
                {
                    return -1;
                }

                return Math.Max(left, right) + 1;
            }
        }
    }
}
