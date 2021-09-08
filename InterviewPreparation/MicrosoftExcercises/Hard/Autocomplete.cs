//using System.Collections.Generic;
//using System.Text;

//namespace InterviewPreparation.MicrosoftExcercises.Hard
//{
//    public class AutocompleteSystem
//    {
//        private StringBuilder currentSentence;
//        private Trie trie;

//        public AutocompleteSystem(string[] sentences, int[] times)
//        {
//            currentSentence = new StringBuilder();
//            trie = GenerateTrie(sentences, times);
//        }

//        public IList<string> Input(char c)
//        {
//            if (c == '#')
//            {
//                var sentence = currentSentence.ToString();

//                if (sentence != "")
//                {
//                    trie.AddSentence(sentence, 1);
//                    currentSentence = new StringBuilder();
//                }

//                return new List<string>();
//            }

//            currentSentence.Append(c);

//            return trie.GetHottests(currentSentence.ToString());
//        }

//        private Trie GenerateTrie(string[] sentences, int[] times)
//        {
//            var trie = new Trie();

//            for (int i = 0; i < sentences.Length; i++)
//            {
//                trie.AddSentence(sentences[i], times[i]);
//            }

//            return trie;
//        }
//    }

//    public class Trie
//    {
//        private TrieNode root;

//        public Trie()
//        {
//            root = new TrieNode();
//        }

//        public void AddSentence(string sentence, int frequency)
//        {
//            var current = root;

//            for (int i = 0; i < sentence.Length; i++)
//            {
//                var currentChar = sentence[i];

//                if (!current.Links.ContainsKey(currentChar))
//                {
//                    current.Links.Add(currentChar, new TrieNode());
//                }

//                current = current.Links[currentChar];
//            }

//            current.Sentence = sentence;
//            current.Frequency += frequency;
//        }

//        public IList<string> GetHottests(string prefix)
//        {
//            var hottests = new List<string>();
//            var current = root;

//            for (int i = 0; i < prefix.Length; i++)
//            {
//                var currentChar = prefix[i];

//                if (!current.Links.ContainsKey(currentChar))
//                {
//                    return hottests;
//                }

//                current = current.Links[currentChar];
//            }

//            return current.GetAllSentences()
//                .OrderByDescending(item => item.frequency)
//                .ThenBy(item => item.sentence)
//                .Select(item => item.sentence)
//                .Take(3)
//                .ToList();
//        }
//    }

//    public class TrieNode
//    {
//        public int Frequency { get; set; }

//        public string Sentence { get; set; }

//        public Dictionary<char, TrieNode> Links { get; set; }

//        public TrieNode()
//        {
//            Frequency = 0;
//            Sentence = "";
//            Links = new Dictionary<char, TrieNode>();
//        }

//        public IList<(string sentence, int frequency)> GetAllSentences()
//        {
//            var sentences = new List<(string, int)>();
//            var queue = new Queue<TrieNode>();

//            queue.Enqueue(this);

//            while (queue.Count > 0)
//            {
//                var actual = queue.Dequeue();

//                if (actual.Sentence != "")
//                {
//                    sentences.Add((actual.Sentence, actual.Frequency));
//                }

//                foreach (var node in actual.Links.Values)
//                {
//                    queue.Enqueue(node);
//                }
//            }

//            return sentences;
//        }
//    }

//    /**
//     * Your AutocompleteSystem object will be instantiated and called as such:
//     * AutocompleteSystem obj = new AutocompleteSystem(sentences, times);
//     * IList<string> param_1 = obj.Input(c);
//     */
//}
