using System.Collections.Generic;

namespace InterviewPreparation.Exercises
{
    public class SetZeroesMatrix
    {
        public void SetZeroes(int[][] matrix)
        {
            if (matrix != null)
            {
                var coordinates = new Queue<int[]>();
                var zeroesRow = new int[matrix[0].Length];

                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        if (matrix[i][j] == 0)
                        {
                            coordinates.Enqueue(new int[] { i, j });
                        }
                    }
                }

                while (coordinates.Count > 0)
                {
                    var actual = coordinates.Dequeue(); // [x,y]
                    var i = actual[0];
                    var j = actual[1];

                    matrix[i] = zeroesRow; //Add zeroes to the row                    

                    for (int row = 0; row < matrix.Length; row++) //Add zeroes to the column
                    {
                        matrix[row][j] = 0;
                    }
                }
            }
        }
    }
}
