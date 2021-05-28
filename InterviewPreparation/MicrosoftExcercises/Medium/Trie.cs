using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    public class Trie
    {

        private TrieNode root;

        /** Initialize your data structure here. */
        public Trie()
        {
            root = new TrieNode();
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            var actual = root;

            for (int i = 0; i < word.Length; i++)
            {
                var currentChar = word[i];

                if (!actual.ContainsKey(currentChar))
                {
                    actual.Put(currentChar, new TrieNode());
                }

                actual = actual.Get(currentChar);
            }

            actual.setEnd();
        }

        private TrieNode searchPrefix(string word)
        {
            var actual = root;

            for (int i = 0; i < word.Length; i++)
            {
                var currentChar = word[i];

                if (actual.ContainsKey(currentChar))
                {
                    actual = actual.Get(currentChar);
                }
                else
                {
                    return null;
                }
            }

            return actual;
        }


        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            var node = searchPrefix(word);

            return node != null && node.isEnd();
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            var node = searchPrefix(prefix);

            return node != null;
        }
    }

    public class TrieNode
    {
        private Dictionary<char, TrieNode> links;
        private bool isWord;

        public TrieNode()
        {
            links = new Dictionary<char, TrieNode>();
        }

        public bool ContainsKey(char ch)
        {
            return links.ContainsKey(ch);
        }

        public TrieNode Get(char ch)
        {
            return links.ContainsKey(ch) ? links[ch] : null;
        }

        public void Put(char ch, TrieNode node)
        {
            links.Add(ch, node);
        }

        public void setEnd()
        {
            isWord = true;
        }

        public bool isEnd()
        {
            return isWord;
        }
    }

    /**
     * Your Trie object will be instantiated and called as such:
     * Trie obj = new Trie();
     * obj.Insert(word);
     * bool param_2 = obj.Search(word);
     * bool param_3 = obj.StartsWith(prefix);
     */
}
