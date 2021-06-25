using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class SpiralMatrix
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            var spiralOrder = new List<int>();

            var left = 0;
            var right = matrix[0].Length - 1;
            var top = 0;
            var bottom = matrix.Length - 1;
            var totalExpected = matrix[0].Length * matrix.Length;

            while (spiralOrder.Count < totalExpected)
            {
                for (int i = left; i <= right && spiralOrder.Count < totalExpected; i++)
                {
                    spiralOrder.Add(matrix[top][i]);
                }

                for (int i = top + 1; i <= bottom && spiralOrder.Count < totalExpected; i++)
                {
                    spiralOrder.Add(matrix[i][right]);
                }

                for (int i = right - 1; i >= left && spiralOrder.Count < totalExpected; i--)
                {
                    spiralOrder.Add(matrix[bottom][i]);
                }

                for (int i = bottom - 1; i > top && spiralOrder.Count < totalExpected; i--)
                {
                    spiralOrder.Add(matrix[i][left]);
                }

                left++;
                top++;
                right--;
                bottom--;
            }

            return spiralOrder;
        }
    }
}
