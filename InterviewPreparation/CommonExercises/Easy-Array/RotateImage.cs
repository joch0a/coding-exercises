using System;

namespace InterviewPreparation.CommonExercises.Easy_Array
{
    class RotateImage
    {
        //https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/770/

        //hard way
        public void Rotate(int[][] matrix)
        {
            var n = matrix.Length;
            for (int i = 0; i < n / 2 + n % 2; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    var aux = matrix[n - 1 - j][i];
                    matrix[n - 1 - j][i] = matrix[n - 1 - i][n - 1 - j];
                    matrix[n - 1 - i][n - 1 - j] = matrix[j][n - 1 - i];
                    matrix[j][n - 1 - i] = matrix[i][j];
                    matrix[i][j] = aux;
                }
            }
        }

        //easy way
        public void RotateFancy(int[][] matrix)
        {
            var n = matrix.Length;

            for (int i = 0; i < n ; i++)
            {
                for (int j = 0; j < i ; j++)
                {
                    var aux = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = aux;
                }
            }

            for (int i = 0; i < n; i++)
            {
                Array.Reverse(matrix[i]);
            }
        }
    }
}
