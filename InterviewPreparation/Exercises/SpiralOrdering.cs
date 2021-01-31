using System.Collections.Generic;

namespace InterviewPreparation.Exercises
{
    public class SpiralOrdering
    {
        public class Solution
        {
            public IList<int> SpiralOrder(int[][] matrix)
            {
                //  0 right j + 1
                //  1 down  i + 1
                //  2 left  j - 1  
                //  3 up    i - 1
                var spiral = new List<int>();
                var rowMin = 0;
                var rowMax = matrix.Length - 1;
                var colMin = 0;
                var colMax = matrix[0].Length - 1;
                int currentCol, currentRow;


                while (colMin <= colMax && rowMin <= rowMax)
                {
                    currentCol = colMin;

                    for (int j = currentCol; j <= colMax; j++)
                    {
                        spiral.Add(matrix[rowMin][j]);
                    }

                    currentRow = rowMin + 1;

                    for (int i = currentRow; i <= rowMax; i++)
                    {
                        spiral.Add(matrix[i][colMax]);
                    }

                    if (colMax != colMin && rowMax != rowMin)
                    {
                        currentCol = colMax - 1;

                        for (int j = currentCol; j >= colMin; j--)
                        {
                            spiral.Add(matrix[rowMax][j]);
                        }

                        currentRow = rowMax - 1;

                        for (int i = currentRow; i > rowMin; i--)
                        {
                            spiral.Add(matrix[i][colMin]);
                        }
                    }

                    rowMin++;
                    colMin++;
                    rowMax--;
                    colMax--;
                }

                return spiral;
            }
        }
    }
}
