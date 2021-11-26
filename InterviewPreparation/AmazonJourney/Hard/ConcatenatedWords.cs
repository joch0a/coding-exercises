using System.Collections.Generic;

namespace InterviewPreparation.AmazonJourney.Hard
{
    public class Solution
    {
        public IList<string> FindAllConcatenatedWordsInADict(string[] words)
        {
            var trie = new Trie(words);
            var concatenatedWords = new List<string>();

            foreach (var word in words)
            {
                var cache = new bool?[word.Length + 1];

                if (IsConcatenatedWord(word, trie._root, startIndex: 0, containedWords: 0, cache: cache))
                {
                    concatenatedWords.Add(word);
                }
            }

            return concatenatedWords;
        }

        private bool IsConcatenatedWord(string word, TrieNode root, int startIndex, int containedWords, bool?[] cache)
        {
            if (startIndex == word.Length && containedWords > 1)
            {
                return true;
            }

            if (cache[startIndex] != null)
            {
                return cache[startIndex].Value;
            }

            var current = root;
            var result = false;

            for (int i = startIndex; i < word.Length && !result; i++)
            {
                var currentChar = word[i];

                if (!current.Links.ContainsKey(currentChar))
                {
                    break;
                }

                current = current.Links[currentChar];

                if (current.Word != "" && current.Word != word)
                {
                    result |= IsConcatenatedWord(word, root, i + 1, containedWords + 1, cache);
                }
            }

            cache[startIndex] = result;

            return result;
        }
    }

    public class Trie
    {
        public TrieNode _root { get; set; }

        public Trie(string[] words)
        {
            _root = new TrieNode();

            BuildTrie(words);
        }

        public void AddWord(string word)
        {
            var current = _root;

            for (int index = 0; index < word.Length; index++)
            {
                var currentChar = word[index];

                if (!current.Links.ContainsKey(currentChar))
                {
                    current.Links.Add(currentChar, new TrieNode());
                }

                current = current.Links[currentChar];
            }

            current.Word = word;
        }

        private void BuildTrie(string[] words)
        {
            foreach (var word in words)
            {
                AddWord(word);
            }
        }

    }

    public class TrieNode
    {
        public string Word { get; set; }

        public Dictionary<char, TrieNode> Links { get; set; }

        public TrieNode()
        {
            Word = string.Empty;
            Links = new Dictionary<char, TrieNode>();
        }
    }

}
