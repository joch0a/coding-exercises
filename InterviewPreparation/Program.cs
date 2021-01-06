using System;
using System.Collections.Generic;

namespace InterviewPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] a = { '1', '1', '1' };
            char[] b = { '0', '1', '0' };
            char[] c = { '1', '1', '1' };
            char[][] islands = {
                  a,b,c
              };

            var numberOfIslands = NumIslands(islands);
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
            var max = long.MinValue;
            var maxSecond = long.MinValue;
            var maxThird = long.MinValue;
            long count = 0;

            foreach (var num in nums)
            {
                Process(num, ref max, ref maxSecond, ref maxThird, ref count);
            }

            return count >= 3 ? (int)maxThird : (int)max;
        }

        public static void Process(int value, ref long max1, ref long max2, ref long max3, ref long count)
        {
            if (value == long.MinValue || (value != max1 && value != max3 && value != max2))
            {
                count++;
                long aux;

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
        public static int NumIslands(char[][] grid)
        {
            var numberOfIslands = 0;

            if (grid.Length > 0)
            {
                var visited = new bool[grid.Length, grid[0].Length];

                for (var i = 0; i < grid.Length; i++)
                {
                    for (var j = 0; j < grid[i].Length; j++)
                    {
                        if (!visited[i, j])
                        {
                            explore(grid, visited, ref numberOfIslands, i, j);
                        }
                    }
                }
            }

            return numberOfIslands;
        }

        private static void explore(char[][] grid, bool[,] visited, ref int numberOfIslands, int i, int j)
        {
            var nodesToVisit = new Stack<Tuple<int, int>>();
            var islandFound = false;

            nodesToVisit.Push(new Tuple<int, int>(i, j));

            while (nodesToVisit.Count > 0)
            {
                var actualNode = nodesToVisit.Pop();

                if (!visited[actualNode.Item1, actualNode.Item2])
                {
                    visited[actualNode.Item1, actualNode.Item2] = true;

                    if (grid[actualNode.Item1][actualNode.Item2] == '1')
                    {
                        islandFound = true;
                        var neighbours = GetNeighbours(grid, visited, actualNode.Item1, actualNode.Item2);

                        foreach (var neighbour in neighbours)
                        {
                            nodesToVisit.Push(neighbour);
                        }
                    }
                }
            }

            if (islandFound)
            {
                numberOfIslands++;
            }
        }

        private static IEnumerable<Tuple<int, int>> GetNeighbours(char[][] grid, bool[,] visited, int i, int j)
        {
            var neighbours = new List<Tuple<int, int>>();

            if (i > 0 && !visited[i - 1, j])
            {
                neighbours.Add(new Tuple<int, int>(i - 1, j));
            }

            if (j > 0 && !visited[i, j - 1])
            {
                neighbours.Add(new Tuple<int, int>(i, j - 1));
            }

            if (i < grid.Length - 1 && !visited[i + 1, j])
            {
                neighbours.Add(new Tuple<int, int>(i + 1, j));
            }

            if (j < grid[i].Length - 1 && !visited[i, j + 1])
            {
                neighbours.Add(new Tuple<int, int>(i, j + 1));
            }

            return neighbours;
        }

        //Code from Leetcode more optimized
        //public int NumIslands(char[][] grid)
        //{

        //    if (grid == null || grid.Length == 0)
        //    {
        //        return 0;
        //    }

        //    int numberOfIslands = 0;

        //    for (int i = 0; i < grid.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < grid[i].Length; j++)
        //        {
        //            char v = grid[i][j];
        //            if (v == '1')
        //            {
        //                numberOfIslands += sink(grid, i, j);
        //            }
        //        }
        //    }

        //    return numberOfIslands;
        //}

        //public int sink(char[][] grid, int i, int j)
        //{
        //    if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] == '0')
        //    {
        //        return 0;
        //    }

        //    grid[i][j] = '0';
        //    sink(grid, i, j + 1);
        //    sink(grid, i, j - 1);
        //    sink(grid, i + 1, j);
        //    sink(grid, i - 1, j);
        //    return 1;
        //}
    }
}
