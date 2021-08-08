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
        var currentNode = root;

        for (int i = 0; i < word.Length; i++)
        {
            currentNode = currentNode.GetOrInsert(word[i]);
        }

        currentNode.Word = word;
    }

    /** Returns if the word is in the trie. */
    public bool Search(string word)
    {
        var currentNode = root;

        for (int i = 0; i < word.Length && currentNode != null; i++)
        {
            currentNode = currentNode.Get(word[i]);
        }

        return currentNode != null && currentNode.Word == word;
    }

    /** Returns if there is any word in the trie that starts with the given prefix. */
    public bool StartsWith(string word)
    {
        var currentNode = root;

        for (int i = 0; i < word.Length && currentNode != null; i++)
        {
            currentNode = currentNode.Get(word[i]);
        }

        return currentNode != null;
    }
}

public class TrieNode
{
    public Dictionary<char, TrieNode> Links { get; set; }
    public string Word { get; set; }

    public TrieNode()
    {
        Word = "";
        Links = new Dictionary<char, TrieNode>();
    }

    public TrieNode GetOrInsert(char current)
    {
        if (!Links.ContainsKey(current))
        {
            Links.Add(current, new TrieNode());
        }

        return Links[current];
    }

    public TrieNode Get(char current)
    {
        if (!Links.ContainsKey(current))
        {
            return null;
        }

        return Links[current];
    }
}
