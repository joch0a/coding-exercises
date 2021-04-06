using System.Collections.Generic;

namespace InterviewPreparation.Exercises
{
    class WordSearch
    {
        public bool Exist(char[][] board, string word)
        {
            var exist = false;

            for (int i = 0; i < board.Length && !exist; i++)
            {
                for (int j = 0; j < board[0].Length && !exist; j++)
                {
                    if (board[i][j] == word[0])
                    {
                        var tmp = board[i][j];
                        board[i][j] = '*';

                        if (Exist(board, word, 1, i, j))
                        {
                            return true;
                        }

                        board[i][j] = tmp;
                    }
                }
            }

            return false;
        }

        private bool Exist(char[][] board,
                           string word,
                           int index,
                           int i,
                           int j)
        {
            if (index == word.Length)
            {
                return true;
            }

            var neighbours = GetNeighbours(i, j, board, index, word);

            foreach (var neighbour in neighbours)
            {
                var tmp = board[neighbour[0]][neighbour[1]];
                board[neighbour[0]][neighbour[1]] = '*';

                if (Exist(board, word, index + 1, neighbour[0], neighbour[1]))
                {
                    return true;
                }

                board[neighbour[0]][neighbour[1]] = tmp;
            }

            return false;
        }

        private List<int[]> GetNeighbours(int i, int j, char[][] board, int index, string word)
        {
            List<int[]> neighbours = new List<int[]>();

            if (i > 0 && board[i - 1][j] == word[index])
            {
                neighbours.Add(new int[] { i - 1, j });
            }

            if (j > 0 && board[i][j - 1] == word[index])
            {
                neighbours.Add(new int[] { i, j - 1 });
            }

            if (i < board.Length - 1 && board[i + 1][j] == word[index])
            {
                neighbours.Add(new int[] { i + 1, j });
            }

            if (j < board[0].Length - 1 && board[i][j + 1] == word[index])
            {
                neighbours.Add(new int[] { i, j + 1 });
            }

            return neighbours;
        }
    }
}
