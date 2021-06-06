using InterviewPreparation.Exercises;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class FindDuplicatesSubtree
    {
        public IList<TreeNode> duplicates = new List<TreeNode>();
        public Dictionary<string, int> trees = new Dictionary<string, int>();

        public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
        {
            if (root == null)
            {
                return new List<TreeNode>();
            }

            Traverse(root);

            return duplicates;
        }

        public string Traverse(TreeNode root)
        {
            if (root == null)
            {
                return "#";
            }

            var subTree = $"{root.val} {Traverse(root.left)} {Traverse(root.right)}";

            if (trees.ContainsKey(subTree))
            {
                if (trees[subTree] == 1)
                {
                    duplicates.Add(root);
                }
            }
            else
            {
                trees.Add(subTree, 0);
            }

            trees[subTree] += 1;

            return subTree;
        }
    }
}
