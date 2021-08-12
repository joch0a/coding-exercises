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

        public void SetZeroesReview(int[][] matrix)
        {
            var colZero = false;
            var rowZero = false;

            //col check
            for (int i = 0; i < matrix.Length && !colZero; i++)
            {
                if (matrix[i][0] == 0)
                {
                    colZero = true;
                }
            }

            //row check
            for (int j = 0; j < matrix[0].Length && !rowZero; j++)
            {
                if (matrix[0][j] == 0)
                {
                    rowZero = true;
                }
            }

            //create marks

            for (int i = 1; i < matrix.Length; i++)
            {
                for (int j = 1; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[i][0] = 0;
                        matrix[0][j] = 0;
                    }
                }
            }

            //vertical flood

            for (int j = 1; j < matrix[0].Length; j++)
            {
                if (matrix[0][j] == 0)
                {
                    for (int i = 0; i < matrix.Length; i++)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }


            //horizontal flood
            for (int i = 1; i < matrix.Length; i++)
            {
                if (matrix[i][0] == 0)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }

            if (matrix[0][0] == 0)
            {
                for (int j = 1; j < matrix[0].Length; j++)
                {
                    matrix[0][j] = 0;
                }
            }

            if (colZero)
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    matrix[i][0] = 0;
                }
            }

            if (rowZero)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    matrix[0][j] = 0;
                }
            }
        }
    }
}
