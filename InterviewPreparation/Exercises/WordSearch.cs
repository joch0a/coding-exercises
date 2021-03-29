using System.Collections.Generic;

namespace InterviewPreparation.Exercises
{
    class WordSearch
    {
        //Fist approach 46/47 tests need to improve

        public bool Exist(char[][] board, string word)
        {
            var visited = new bool[board.Length][];

            for (int i = 0; i < board.Length; i++)
            {
                visited[i] = new bool[board[0].Length];
            }

            var exist = false;

            for (int i = 0; i < board.Length && !exist; i++)
            {
                for (int j = 0; j < board[0].Length && !exist; j++)
                {
                    if (board[i][j] == word[0])
                    {
                        visited[i][j] = true;

                        if (Exist(visited, board, word, 1, i, j))
                        {
                            return true;
                        }

                        visited[i][j] = false;
                    }
                }
            }

            return false;
        }

        private bool Exist(bool[][] visited,
                           char[][] board,
                           string word,
                           int index,
                           int i,
                           int j)
        {
            if (index == word.Length)
            {
                return true;
            }

            var neighbours = GetNeighbours(i, j, visited, board, index, word);

            foreach (var neighbour in neighbours)
            {
                visited[neighbour[0]][neighbour[1]] = true;

                if (Exist(visited, board, word, index + 1, neighbour[0], neighbour[1]))
                {
                    return true;
                }

                visited[neighbour[0]][neighbour[1]] = false;
            }

            return false;
        }

        private List<int[]> GetNeighbours(int i, int j, bool[][] visited,
                           char[][] board, int index, string word)
        {
            List<int[]> neighbours = new List<int[]>();

            if (i > 0 && !visited[i - 1][j] && board[i - 1][j] == word[index])
            {
                neighbours.Add(new int[] { i - 1, j });
            }

            if (j > 0 && !visited[i][j - 1] && board[i][j - 1] == word[index])
            {
                neighbours.Add(new int[] { i, j - 1 });
            }

            if (i < board.Length - 1 && !visited[i + 1][j] && board[i + 1][j] == word[index])
            {
                neighbours.Add(new int[] { i + 1, j });
            }

            if (j < board[0].Length - 1 && !visited[i][j + 1] && board[i][j + 1] == word[index])
            {
                neighbours.Add(new int[] { i, j + 1 });
            }

            return neighbours;
        }
    }
}
