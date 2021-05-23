using InterviewPreparation.Exercises;
using System;
using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class FindSecondMinimumValue
    {
        public int Solve(TreeNode root)
        {
            var min1 = long.MaxValue;
            var result = long.MaxValue;

            var stack = new Stack<TreeNode>();

            stack.Push(root);

            while (stack.Count > 0)
            {
                var actual = stack.Pop();

                if (actual.val < min1)
                {
                    result = min1;
                    min1 = actual.val;
                }
                else if (actual.val != min1)
                {
                    result = Math.Min(actual.val, result);
                }

                if (actual.left != null)
                {
                    stack.Push(actual.left);
                    stack.Push(actual.right);
                }
            }

            return result == long.MaxValue ? -1 : (int)result;
        }
    }
}
