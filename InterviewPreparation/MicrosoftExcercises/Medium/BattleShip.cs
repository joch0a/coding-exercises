namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class BattleShip
    {
        public int CountBattleships(char[][] board)
        {
            var count = 0;
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == 'X' &&
                       ((i == 0 && j == 0) || (i == 0 && j > 0 && board[i][j - 1] != 'X') ||
                        (j == 0 && i > 0 && board[i - 1][j] != 'X') ||
                        (i > 0 && j > 0 && board[i][j - 1] != 'X' && board[i - 1][j] != 'X')))
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
