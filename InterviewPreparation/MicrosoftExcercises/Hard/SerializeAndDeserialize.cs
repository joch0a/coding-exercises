using InterviewPreparation.Exercises;
using System.Collections.Generic;
using System.Linq;

namespace InterviewPreparation.MicrosoftExcercises.Hard
{
    class SerializeAndDeserialize
    {
        public string serialize(TreeNode root)
        {
            var queue = new Queue<TreeNode>();
            var result = new List<string>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var actual = queue.Dequeue();

                result.Add(actual == null ? "null" : actual.val.ToString());

                if (actual != null)
                {
                    queue.Enqueue(actual.left);
                }

                if (actual != null)
                {
                    queue.Enqueue(actual.right);
                }
            }

            return string.Join(',', result);
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            var encoded = data.Split(',').ToArray();

            if (encoded.Length < 1 || encoded[0] == "null")
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

                        if (val != "null")
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

                        if (val != "null")
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
