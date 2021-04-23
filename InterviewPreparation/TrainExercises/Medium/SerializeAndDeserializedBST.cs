using InterviewPreparation.Exercises;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewPreparation.TrainExercises.Medium
{
    class SerializeAndDeserializedBST
    {
        public string serialize(TreeNode root)
        {
            var queue = new Queue<TreeNode>();
            var sb = new StringBuilder();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var actual = queue.Dequeue();

                if (actual == null)
                {
                    sb.Append("#,");
                }
                else
                {
                    sb.Append($"{actual.val},");

                    queue.Enqueue(actual.left);
                    queue.Enqueue(actual.right);
                }
            }

            return sb.ToString().Substring(0, sb.Length - 1);
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            var encoded = data.Split(',').ToArray();

            if (encoded.Length < 1 || encoded[0] == "#")
            {
                return null;
            }

            var head = new TreeNode(int.Parse(encoded[0].ToString()));
            var actual = head;
            var queue = new Queue<TreeNode>();

            int i = 1;

            while (i < encoded.Length)
            {
                if (actual != null)
                {
                    if (i < encoded.Length && actual != null)
                    {
                        var val = encoded[i].ToString();
                        TreeNode left = null;

                        if (val != "#")
                        {
                            left = new TreeNode(int.Parse(val));
                        }

                        actual.left = left;
                        queue.Enqueue(left);
                    }

                    i++;

                    if (i < encoded.Length && actual != null)
                    {
                        var val = encoded[i].ToString();
                        TreeNode right = null;

                        if (val != "#")
                        {
                            right = new TreeNode(int.Parse(val));
                        }

                        actual.right = right;
                        queue.Enqueue(right);
                    }
                    i++;
                }
                actual = queue.Dequeue();
            }

            return head;
        }
    }
}
