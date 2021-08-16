using InterviewPreparation.Exercises;
using System;

namespace InterviewPreparation.MicrosoftExcercises.Premium
{
    class ClosestBinaryTreeValue
    {
        public int ClosestValue(TreeNode root, double target)
        {
            int val, closest = root.val;
            while (root != null)
            {
                val = root.val;
                closest = Math.Abs(val - target) < Math.Abs(closest - target) ? val : closest;
                root = target < root.val ? root.left : root.right;
            }
            return closest;
        }
    }
}
