using System;

namespace InterviewPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
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

        static int maxDiff(Node root, int k)
        {
            int min = Integer.MAX_VALUE;

            while (root != null)
            {
                min = Math.min(min, Math.abs(root.data - k));

                if (k > root.data)
                {
                    root = root.right;
                }
                else if (k < root.data)
                {
                    root = root.left;
                }
                else
                {
                    return 0;
                }
            }

            return min;
        }

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

        //        return min;
        //    }
        //}
    }
}
