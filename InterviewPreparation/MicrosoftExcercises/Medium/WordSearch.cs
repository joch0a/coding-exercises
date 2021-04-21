using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class WordSearch
    {
        public bool Exist(char[][] board, string word)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == word[0])
                    {
                        var tmp = board[i][j];
                        board[i][j] = '*';

                        if (Backtrack(board, word, 1, i, j))
                        {
                            return true;
                        }

                        board[i][j] = tmp;
                    }
                }
            }

            return false;
        }

        public bool Backtrack(char[][] board, string word, int index, int i, int j)
        {
            if (index == word.Length)
            {
                return true;
            }

            var neighbours = GetNeighbours(board, word, index, i, j);

            foreach (var neighbour in neighbours)
            {
                if (board[neighbour[0]][neighbour[1]] != '*')
                {
                    var tmp = board[neighbour[0]][neighbour[1]];

                    board[neighbour[0]][neighbour[1]] = '*';

                    if (Backtrack(board, word, index + 1, neighbour[0], neighbour[1]))
                    {
                        return true;
                    }

                    board[neighbour[0]][neighbour[1]] = tmp;
                }
            }

            return false;
        }

        private List<int[]> GetNeighbours(char[][] matrix, string word, int index, int i, int j)
        {
            var result = new List<int[]>();

            if (i > 0 && matrix[i - 1][j] == word[index])
            {
                result.Add(new int[] { i - 1, j });
            }

            if (j > 0 && matrix[i][j - 1] == word[index])
            {
                result.Add(new int[] { i, j - 1 });
            }

            if (i < matrix.Length - 1 && matrix[i + 1][j] == word[index])
            {
                result.Add(new int[] { i + 1, j });
            }

            if (j < matrix[i].Length - 1 && matrix[i][j + 1] == word[index])
            {
                result.Add(new int[] { i, j + 1 });
            }

            return result;
        }
    }
}
