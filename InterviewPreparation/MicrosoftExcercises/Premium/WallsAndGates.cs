using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Premium
{
    public class WallsAndGates
    {
        private readonly (int, int)[] directions = new (int, int)[] { (-1, 0), (0, -1), (0, 1), (1, 0) };

        public void Solve(int[][] rooms)
        {
            var queue = new Queue<(int, int)>();

            for (int i = 0; i < rooms.Length; i++)
            {
                for (int j = 0; j < rooms[i].Length; j++)
                {
                    if (rooms[i][j] == 0)
                    {
                        queue.Enqueue((i, j));
                    }
                }
            }

            while (queue.Count > 0)
            {
                var (row, col) = queue.Dequeue();

                foreach (var (rowDirection, colDirection) in directions)
                {
                    var newRow = row + rowDirection;
                    var newCol = col + colDirection;

                    if (newRow >= 0 && newRow < rooms.Length &&
                      newCol >= 0 && newCol < rooms[newRow].Length
                      && rooms[newRow][newCol] == int.MaxValue)
                    {
                        queue.Enqueue((newRow, newCol));

                        rooms[newRow][newCol] = rooms[row][col] + 1;
                    }
                }
            }
        }
    }
}
