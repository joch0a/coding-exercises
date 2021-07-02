using System.Collections.Generic;
using System.Text;

namespace InterviewPreparation.MicrosoftExcercises.Hard
{
    class QueensChess
    {
        public IList<IList<string>> SolveNQueens(int n)
        {
            IList<IList<string>> combinations = new List<IList<string>>();

            Backtrack(combinations, 0, CreateChessboard(n), n);

            return combinations;
        }

        private IList<string> CreateResult(char[,] board)
        {
            var result = new List<string>();

            for (int i = 0; i < board.GetLength(0); i++)
            {
                var sb = new StringBuilder();

                for (int j = 0; j < board.GetLength(0); j++)
                {
                    sb.Append(board[i, j]);
                }

                result.Add(sb.ToString());
            }

            return result;
        }

        private void Backtrack(IList<IList<string>> combinations, int rowStart, char[,] combination, int n)
        {
            if (rowStart == n)
            {
                combinations.Add(CreateResult(combination));

                return;
            }

            for (int currentColumn = 0; currentColumn < n; currentColumn++)
            {
                if (!IsUnderAttack(rowStart, currentColumn, combination, n))
                {
                    combination[rowStart, currentColumn] = 'Q';
                    Backtrack(combinations, rowStart + 1, combination, n);
                    combination[rowStart, currentColumn] = '.';
                }
            }
        }

        private char[,] CreateChessboard(int n)
        {
            var board = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    board[i, j] = '.';
                }
            }

            return board;
        }

        public bool IsUnderAttack(int row, int column, char[,] board, int n)
        {
            //check \ diagonal
            var currentRow = row;
            var currentColumn = column;

            while (currentRow > 0 && currentColumn > 0)
            {
                if (board[currentRow - 1, currentColumn - 1] == 'Q')
                {
                    return true;
                }

                currentRow--;
                currentColumn--;
            }
            //check / diagonal

            currentRow = row;
            currentColumn = column;

            while (currentRow > 0 && currentColumn < n - 1)
            {
                if (board[currentRow - 1, currentColumn + 1] == 'Q')
                {
                    return true;
                }

                currentRow--;
                currentColumn++;
            }

            //check vertical

            for (currentRow = 0; currentRow < row; currentRow++)
            {
                if (board[currentRow, column] == 'Q')
                {
                    return true;
                }
            }

            return false;
        }
    }
}
