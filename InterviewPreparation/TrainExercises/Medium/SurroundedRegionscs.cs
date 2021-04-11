using System.Collections.Generic;

namespace InterviewPreparation.TrainExercises.Medium
{
    class SurroundedRegionscs
    {
        public void Solve(char[][] board)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                MarkNotSurrounded(board, 0, j);
                MarkNotSurrounded(board, board.Length - 1, j);
            }

            for (int i = 0; i < board.Length; i++)
            {
                MarkNotSurrounded(board, i, 0);
                MarkNotSurrounded(board, i, board[0].Length - 1);
            }

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == 'O')
                    {
                        board[i][j] = 'X';
                    }
                    if (board[i][j] == '?')
                    {
                        board[i][j] = 'O';
                    }
                }
            }
        }

        private void MarkNotSurrounded(char[][] board, int i, int j)
        {
            if (board[i][j] == 'O')
            {
                var queue = new Queue<int[]>();

                queue.Enqueue(new int[] { i, j });

                while (queue.Count > 0)
                {
                    var actual = queue.Dequeue();

                    if (board[actual[0]][actual[1]] == '?')  // ------------> Instructive line!!! skip duplicates
                    {
                        continue;
                    }

                    board[actual[0]][actual[1]] = '?';

                    AddNeighbours(board, actual[0], actual[1], queue);
                }
            }
        }

        private void AddNeighbours(char[][] board, int i, int j, Queue<int[]> queue)
        {
            if (i > 0 && board[i - 1][j] == 'O')
            {
                queue.Enqueue(new int[] { i - 1, j });
            }

            if (j > 0 && board[i][j - 1] == 'O')
            {
                queue.Enqueue(new int[] { i, j - 1 });
            }

            if (i < board.Length - 1 && board[i + 1][j] == 'O')
            {
                queue.Enqueue(new int[] { i + 1, j });
            }

            if (j < board[i].Length - 1 && board[i][j + 1] == 'O')
            {
                queue.Enqueue(new int[] { i, j + 1 });
            }
        }
    }
}
