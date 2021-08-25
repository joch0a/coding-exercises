using InterviewPreparation.Exercises;
using System;

namespace InterviewPreparation.CommonExercises.Hard_Graph
{
    class BinaryTreeMaximumPathSum
    {
        public class Solution
        {
            public int globalMax = int.MinValue;

            public int MaxPathSum(TreeNode root)
            {
                DFS(root);

                return globalMax;
            }

            public int DFS(TreeNode root)
            {
                if (root == null)
                {
                    return 0;
                }
                else
                {
                    var left = Math.Max(0, DFS(root.left));
                    var right = Math.Max(0, DFS(root.right));

                    globalMax = Math.Max(left + right + root.val, globalMax);

                    return Math.Max(left, right) + root.val;
                }
            }

            public int MaxPathSum2(TreeNode root)
            {
                if (root == null)
                {
                    return 0;
                }

                var max = root.val;

                DFS2(root, ref max);

                return max;
            }

            private int DFS2(TreeNode root, ref int max)
            {
                if (root == null)
                {
                    return 0;
                }

                var left = Math.Max(0, DFS2(root.left, ref max));
                var right = Math.Max(0, DFS2(root.right, ref max));

                max = Math.Max(max, left + right + root.val);

                return Math.Max(left, right) + root.val;
            }
        }
    }
}
