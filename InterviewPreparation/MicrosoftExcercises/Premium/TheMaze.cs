using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Premium
{
    class TheMaze
    {
        private (int, int)[] directions = new (int, int)[] { (-1, 0), (0, -1), (0, 1), (1, 0) };

        public bool HasPath(int[][] maze, int[] start, int[] destination)
        {
            var queue = new Queue<(int, int)>();

            queue.Enqueue((start[0], start[1]));

            while (queue.Count > 0)
            {
                var (row, col) = queue.Dequeue();
                if (row == destination[0] && col == destination[1])
                {
                    return true;
                }

                if (maze[row][col] != -1)
                {
                    maze[row][col] = -1;

                    foreach (var (rowDirection, colDirection) in directions)
                    {
                        int newRow = row + rowDirection;
                        int newCol = col + colDirection;

                        while (newRow >= 0 && newRow < maze.Length &&
                             newCol >= 0 && newCol < maze[newRow].Length &&
                             (maze[newRow][newCol] != 1))
                        {
                            newRow += rowDirection;
                            newCol += colDirection;
                        }

                        newRow -= rowDirection;
                        newCol -= colDirection;

                        if (maze[newRow][newCol] == 0)
                        {
                            queue.Enqueue((newRow, newCol));
                        }
                    }
                }
            }

            return false;
        }
    }
}
