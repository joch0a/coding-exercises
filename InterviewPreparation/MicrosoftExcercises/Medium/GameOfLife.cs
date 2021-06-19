namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class GameOfLife
    {
        private int[] Ys = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };
        private int[] Xs = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };

        public void Solve(int[][] board)
        {
            var neighbours = new int[board.Length, board[0].Length];

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    neighbours[i, j] = CalculateNeighbours(i, j, board);
                }
            }

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    var actualNeighbours = neighbours[i, j];

                    if (board[i][j] == 1 && (actualNeighbours < 2 || actualNeighbours > 3))
                    {
                        board[i][j] = 0;
                    }
                    else if ((board[i][j] == 1 && (actualNeighbours == 2 || actualNeighbours == 3)) ||
                            (board[i][j] == 0 && actualNeighbours == 3))
                    {
                        board[i][j] = 1;
                    }
                }
            }
        }

        public int CalculateNeighbours(int i, int j, int[][] board)
        {
            var total = 0;

            for (int index = 0; index < Xs.Length; index++)
            {
                var y = Ys[index] + i;
                var x = Xs[index] + j;

                if (y >= 0 &&
                   y < board.Length &&
                   x >= 0 &&
                   x < board[i].Length &&
                   board[y][x] == 1)
                {
                    total++;
                }
            }

            return total;
        }
    }
}
