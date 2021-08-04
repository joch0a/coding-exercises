using System.Collections.Generic;
using System.Linq;

namespace InterviewPreparation.MicrosoftExcercises.Hard
{
    public class Solution
    {
        private int[] Ys = new int[] { -1, 0, 0, 1 };
        private int[] Xs = new int[] { 0, -1, 1, 0 };
        public IList<string> FindWords(char[][] board, string[] words)
        {
            var trie = new Trie();
            var wordsSet = words.ToHashSet();
            foreach (var word in wordsSet)
            {
                trie.AddWord(word);
            }
            IList<string> result = new List<string>();
            for (int row = 0; row < board.Length; row++)
            {
                for (int col = 0; col < board[row].Length; col++)
                {
                    var aux = board[row][col];
                    if (trie.Root.Contains(aux))
                    {
                        board[row][col] = '*';
                        Backtrack(row, col, trie.Root.GetChildren(aux), board, result);
                        board[row][col] = aux;
                    }
                }
            }
            return result.Distinct().ToList();
        }
        private void Backtrack(int startRow, int startCol, TrieNode currentNode, char[][] board, IList<string> result)
        {
            if (currentNode.Word != "")
            {
                result.Add(currentNode.Word);
            }
            var neighbours = GetNeighbours(startRow, startCol, board);
            foreach (var neighbour in neighbours)
            {
                var neighbourRow = neighbour[0];
                var neighbourCol = neighbour[1];
                var aux = board[neighbourRow][neighbourCol];
                if (currentNode.Contains(aux))
                {
                    board[neighbourRow][neighbourCol] = '*';
                    Backtrack(neighbourRow, neighbourCol, currentNode.GetChildren(aux), board, result);
                    board[neighbourRow][neighbourCol] = aux;
                }
            }
        }
        private IList<int[]> GetNeighbours(int row, int col, char[][] board)
        {
            IList<int[]> neighbours = new List<int[]>();
            for (int index = 0; index < Xs.Length; index++)
            {
                var newRow = row + Ys[index];
                var newCol = col + Xs[index];
                if (newRow >= 0 && newRow < board.Length
                  && newCol >= 0 && newCol < board[newRow].Length
                  && board[newRow][newCol] != '*')
                {
                    neighbours.Add(new int[] { newRow, newCol });
                }
            }
            return neighbours;
        }
    }
    public class TrieNode
    {
        public string Word { get; set; }
        public Dictionary<char, TrieNode> Links { get; set; }
        public TrieNode()
        {
            Links = new Dictionary<char, TrieNode>();
            Word = string.Empty;
        }
        public bool Contains(char ch)
        {
            return Links.ContainsKey(ch);
        }
        public TrieNode GetChildren(char cr)
        {
            return Links[cr];
        }
        public TrieNode AddOrReturnExisting(char ch)
        {
            if (!Links.ContainsKey(ch))
            {
                Links.Add(ch, new TrieNode());
            }
            return Links[ch];
        }
    }
    public class Trie
    {
        public TrieNode Root { get; set; }
        public Trie()
        {
            Root = new TrieNode();
        }
        public void AddWord(string word)
        {
            var currentNode = Root;
            for (int index = 0; index < word.Length; index++)
            {
                var currentChar = word[index];
                currentNode = currentNode.AddOrReturnExisting(currentChar);
            }
            currentNode.Word = word;
        }
    }
}
