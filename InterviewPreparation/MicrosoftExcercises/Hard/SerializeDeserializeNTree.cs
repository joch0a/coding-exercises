using System.Collections.Generic;
using System.Text;

namespace InterviewPreparation.MicrosoftExcercises.Hard
{
    class SerializeDeserializeNTree
    {
        public string serialize(Node root)
        {
            if (root == null)
            {
                return "";
            }

            var serialized = new StringBuilder();
            var queue = new Queue<(Node node, int parent)>();

            queue.Enqueue((root, -1));
            var identity = 0;

            while (queue.Count > 0)
            {
                var actual = queue.Dequeue();

                serialized.Append((char)(identity + '0'));
                serialized.Append((char)(actual.node.val + '0'));
                serialized.Append((char)(actual.parent + '0'));

                foreach (var node in actual.node.children)
                {
                    queue.Enqueue((node, identity));
                }

                identity++;
            }

            return serialized.ToString();
        }

        // Decodes your encoded data to tree.
        public Node deserialize(string data)
        {
            if (data == "")
            {
                return null;
            }

            var dict = new Dictionary<int, Node>();

            for (int i = 0; i < data.Length; i += 3)
            {
                int id = data[i] - '0';
                int val = data[i + 1] - '0';

                var node = new Node(val);

                dict.Add(id, node);
            }

            for (int i = 3; i < data.Length; i += 3)
            {
                int childrenId = data[i] - '0';
                int parentId = data[i + 2] - '0';
                var children = dict[childrenId];
                var parent = dict[parentId];

                parent.children.Add(children);
            }

            return dict[0];
        }
    }
}
