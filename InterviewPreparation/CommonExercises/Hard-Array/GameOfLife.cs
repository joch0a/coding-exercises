namespace InterviewPreparation.CommonExercises.Hard_Array
{
    class GameOfLife
    {
        public int[,] neighbours;
        
        public void Solve(int[][] board)
        {
            neighbours = new int[board.Length, board[0].Length];

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    CalculateNeighbours(board, i, j);
                }
            }

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == 1 && (neighbours[i, j] < 2 || neighbours[i, j] > 3))
                    {
                        board[i][j] = 0;
                    }
                    else if (board[i][j] == 0 && neighbours[i, j] == 3)
                    {
                        board[i][j] = 1;
                    }
                }
            }
        }

        private void CalculateNeighbours(int[][] board, int i, int j)
        {
            if (i > 0 && board[i - 1][j] == 1)
            {
                neighbours[i, j]++;
            }

            if (j > 0 && board[i][j - 1] == 1)
            {
                neighbours[i, j]++;
            }

            if (i < board.Length - 1 && board[i + 1][j] == 1)
            {
                neighbours[i, j]++;
            }

            if (j < board[i].Length - 1 && board[i][j + 1] == 1)
            {
                neighbours[i, j]++;
            }

            if (i > 0 && j > 0 && board[i - 1][j - 1] == 1)
            {
                neighbours[i, j]++;
            }

            if (i > 0 && j < board[i].Length - 1 && board[i - 1][j + 1] == 1)
            {
                neighbours[i, j]++;
            }

            if (i < board.Length - 1 && j > 0 && board[i + 1][j - 1] == 1)
            {
                neighbours[i, j]++;
            }

            if (i < board.Length - 1 && j < board[i].Length - 1 && board[i + 1][j + 1] == 1)
            {
                neighbours[i, j]++;
            }
        }
    }
}
