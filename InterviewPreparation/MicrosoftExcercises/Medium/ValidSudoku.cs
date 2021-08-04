using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class ValidSudoku
    {
        public bool IsValidSudoku(char[][] board)
        {
            var seen = GenerateCandidates(board);

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    var current = board[i][j];

                    if (current != '.')
                    {
                        var currentBox = GetBox(i, j);

                        if (seen[currentBox].Contains(current))
                        {
                            return false;
                        }

                        seen[currentBox].Add(current);

                        if (!IsValid(current, i, j, board))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private int GetBox(int i, int j)
        {
            if (i >= 0 && i <= 2 && j >= 0 && j <= 2)
            {
                return 1;
            }
            if (i >= 0 && i <= 2 && j >= 3 && j <= 5)
            {
                return 2;
            }
            if (i >= 0 && i <= 2 && j >= 6 && j <= 9)
            {
                return 3;
            }
            //-----------------
            if (i >= 3 && i <= 5 && j >= 0 && j <= 2)
            {
                return 4;
            }
            if (i >= 3 && i <= 5 && j >= 3 && j <= 5)
            {
                return 5;
            }
            if (i >= 3 && i <= 5 && j >= 6 && j <= 9)
            {
                return 6;
            }
            //------------------
            if (i >= 6 && i <= 9 && j >= 0 && j <= 2)
            {
                return 7;
            }
            if (i >= 6 && i <= 9 && j >= 3 && j <= 5)
            {
                return 8;
            }
            if (i >= 6 && i <= 9 && j >= 6 && j <= 9)
            {
                return 9;
            }

            return -1;
        }

        private Dictionary<int, HashSet<char>> GenerateCandidates(char[][] board)
        {
            var seen = new Dictionary<int, HashSet<char>>();

            for (int i = 1; i < 10; i++)
            {
                seen.Add(i, new HashSet<char>());
            }

            return seen;
        }

        public bool IsValid(char current, int row, int col, char[][] board)
        {
            //vertical check
            for (int i = 0; i < board.Length; i++)
            {
                if (i != row && board[i][col] == current)
                {
                    return false;
                }
            }

            //horizontal check
            for (int j = 0; j < board[0].Length; j++)
            {
                if (j != col && board[row][j] == current)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
