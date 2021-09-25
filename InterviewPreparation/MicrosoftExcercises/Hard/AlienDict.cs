using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewPreparation.MicrosoftExcercises.Hard
{
    class AlienDict
    {
        public class Solution
        {
            public string AlienOrder(string[] words)
            {
                var alienOrder = new StringBuilder();
                var graph = BuildGraph(words.ToArray());

                if (graph == null)
                {
                    return "";
                }

                var queue = new Queue<char>();

                foreach (var tuple in graph)
                {
                    if (graph[tuple.Key].Count == 0)
                    {
                        queue.Enqueue(tuple.Key);
                    }
                }

                while (queue.Count > 0)
                {
                    var actual = queue.Dequeue();

                    alienOrder.Append(actual);

                    foreach (var node in graph.Keys.ToList())
                    {
                        if (graph[node].Contains(actual))
                        {
                            graph[node].Remove(actual);

                            if (graph[node].Count == 0)
                            {
                                queue.Enqueue(node);
                            }
                        }
                    }
                }

                return alienOrder.Length == graph.Count ? alienOrder.ToString() : "";
            }

            private Dictionary<char, IList<char>> BuildGraph(string[] words)
            {
                var trie = BuildTrie(words);

                if (trie == null)
                {
                    return null;
                }

                var graph = new Dictionary<char, IList<char>>();
                var queue = new Queue<TrieNode>();

                queue.Enqueue(trie.root);

                while (queue.Count > 0)
                {
                    var queueSize = queue.Count;

                    while (queueSize > 0)
                    {
                        var actual = queue.Dequeue();

                        var dependecies = new List<char>();

                        if (actual.Value != '$' && actual.Children.Count == 0)
                        {
                            if (!graph.ContainsKey(actual.Value))
                            {
                                graph.Add(actual.Value, new List<char>());
                            }
                        }

                        foreach (var child in actual.Children)
                        {
                            AddDependeciesToGraph(graph, dependecies, child.Value);

                            dependecies.Add(child.Value);

                            queue.Enqueue(child);
                        }

                        queueSize--;
                    }
                }

                return graph;
            }

            private void AddDependeciesToGraph(Dictionary<char, IList<char>> graph,
                                               IList<char> deps,
                                                char node)
            {
                if (!graph.ContainsKey(node))
                {
                    graph.Add(node, new List<char>());
                }

                foreach (var dep in deps)
                {
                    if (!graph.ContainsKey(dep))
                    {
                        graph.Add(dep, new List<char>());
                    }

                    if (!graph[node].Contains(dep))
                    {
                        graph[node].Add(dep);
                    }
                }
            }

            private Trie BuildTrie(string[] words)
            {
                var trie = new Trie();

                foreach (var word in words)
                {
                    if (!trie.AddWord(word))
                    {
                        return null;
                    }
                }

                return trie;
            }
        }

        public class Trie
        {
            public TrieNode root { get; set; }

            public Trie()
            {
                root = new TrieNode('$');
            }

            public bool AddWord(string word)
            {
                var current = root;

                for (int i = 0; i < word.Length; i++)
                {
                    var actualChar = word[i];
                    var next = current.Children.FirstOrDefault(element => element.Value == actualChar);

                    // Console.WriteLine($"{word}:{next?.Value}");

                    if (next == null)
                    {
                        current.Children.AddLast(new TrieNode(actualChar));
                        next = current.Children.Last();
                    }
                    else if (next != current.Children.Last())
                    {
                        // Console.WriteLine("enters");
                        return false;
                    }

                    current = next;
                }

                if (current.Children.Count > 0)
                {
                    return false;
                }

                return true;
            }
        }

        public class TrieNode
        {
            public char Value { get; set; }
            public LinkedList<TrieNode> Children { get; set; }

            public TrieNode(char val)
            {
                Value = val;
                Children = new LinkedList<TrieNode>();
            }
        }
    }
}
