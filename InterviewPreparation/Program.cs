using System;

namespace InterviewPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            ThirdMax(new int[] { -2147483648, -2147483648, -2147483648, -2147483648, 1, 1, 1 });
            Console.WriteLine("Hello World!");
        }


        // problem: https://leetcode.com/problems/is-subsequence/
        // cool video: https://www.youtube.com/watch?v=UsPWwTY0xr4&ab_channel=NareshGupta

        public static bool IsSubsequence(string s, string t)
        {
            var i = 0;
            var j = 0;

            while (i < s.Length && j < t.Length)
            {
                if (s[i] == s[j])
                {
                    i++;
                }

                j++;
            }

            return i == s.Length;
        }

        //static int maxDiff(Node root, int k)
        //{
        //    int min = Integer.MAX_VALUE;

        //    while (root != null)
        //    {
        //        min = Math.min(min, Math.abs(root.data - k));

        //        if (k > root.data)
        //        {
        //            root = root.right;
        //        }
        //        else if (k < root.data)
        //        {
        //            root = root.left;
        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //    }

        //    return min;
        //}

        // https://practice.geeksforgeeks.org/problems/find-the-closest-element-in-bst/1#
        //class Solution
        //{
        //    // Return the minimum absolute difference between any tree node and the integer K
        //    static int maxDiff(Node root, int k)
        //    {
        //        int min = Integer.MAX_VALUE;

        //        while (root != null)
        //        {
        //            min = Math.min(min, Math.abs(root.data - k));

        //            if (k > root.data)
        //            {
        //                root = root.right;
        //            }
        //            else if (k < root.data)
        //            {
        //                root = root.left;
        //            }
        //            else
        //            {
        //                return 0;
        //            }
        //        }     
        /**/
        //* Definition for a binary tree node.

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        /**
         * Definition for a binary tree node.
         * public class TreeNode {
         *     public int val;
         *     public TreeNode left;
         *     public TreeNode right;
         *     public TreeNode(int x) { val = x; }
         * }
         *  var node1 = new TreeNode(7);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(11, node1, node2);
            var node4 = new TreeNode(4, node3);
            var node5 = new TreeNode(5, node4);

            var result = HasPathSum(node5, 22);
         */

        // https://leetcode.com/problems/path-sum/submissions/
        public class Solution
        {
            public bool HasPathSum(TreeNode root, int sum)
            {
                if (root == null)
                    return false;
                else if (root.left == null && root.right == null && root.val == sum)
                    return true;
                else
                    return HasPathSum(root.left, sum - root.val) || HasPathSum(root.right, sum - root.val);
            }
        }

        // https://leetcode.com/problems/maximum-depth-of-binary-tree/submissions/

        public int MaxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            return MaxDepthAux(root, 1);
        }

        public int MaxDepthAux(TreeNode root, int sum)
        {
            if (root == null)
            {
                return sum;
            }

            if (root.left == null && root.right == null)
            {
                return sum;
            }

            return Math.Max(MaxDepthAux(root.left, sum + 1), MaxDepthAux(root.right, sum + 1));
        }

        //Internet solution
        public int MaxDepthAlt(TreeNode root)
        {
            if (root == null)
                return 0;

            int left = MaxDepthAlt(root.left);
            int right = MaxDepthAlt(root.right);

            return Math.Max(left, right) + 1;
        }

        //Product sum https://dev.to/sfrasica/algorithms-product-sum-from-an-array-dc6

        // Binary search iterative https://www.techiedelight.com/binary-search/

        // https://leetcode.com/problems/third-maximum-number/

        public static int ThirdMax(int[] nums)
        {
            var max = int.MinValue;
            var maxSecond = int.MinValue;
            var maxThird = int.MinValue;
            int count = 0;

            foreach (var num in nums)
            {
                Process(num, ref max, ref maxSecond, ref maxThird, ref count);
            }

            return count >= 3 ? maxThird : max;
        }

        public static void Process(int value, ref int max1, ref int max2, ref int max3, ref int count)
        {
            if (value == int.MinValue || value != max1 && value != max3 && value != max2)
            {
                count++;
                int aux;

                if (value >= max3)
                {
                    max3 = value;
                }

                if (max3 >= max2)
                {
                    aux = max2;
                    max2 = max3;
                    max3 = aux;
                }

                if (max2 > max1)
                {
                    aux = max2;
                    max2 = max1;
                    max1 = aux;
                }
            }
        }
    }
}
