namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class ValidTicTacToe
    {
        public bool Solve(string[] board)
        {
            var Xs = 0;
            var Os = 0;

            foreach (var row in board)
            {
                foreach (var cell in row)
                {
                    if (cell == 'X')
                    {
                        Xs++;
                    }

                    if (cell == 'O')
                    {
                        Os++;
                    }
                }
            }

            if (Xs != Os && Xs - 1 != Os)
            {
                return false;
            }

            if (IsWinner(board, 'X') && Xs - 1 != Os)
            {
                return false;
            }

            if (IsWinner(board, 'O') && Xs != Os)
            {
                return false;
            }

            return true;
        }

        public bool IsWinner(string[] board, char player)
        {
            return  (board[0][0] == player && board[0][1] == player && board[0][2] == player) ||
                    (board[1][0] == player && board[1][1] == player && board[1][2] == player) ||
                    (board[2][0] == player && board[2][1] == player && board[2][2] == player) ||
                    (board[0][0] == player && board[1][0] == player && board[2][0] == player) ||
                    (board[0][1] == player && board[1][1] == player && board[2][1] == player) ||
                    (board[0][2] == player && board[1][2] == player && board[2][2] == player) ||
                    (board[0][0] == player && board[1][1] == player && board[2][2] == player) ||
                    (board[2][0] == player && board[1][1] == player && board[0][2] == player);
        }
    }
}
