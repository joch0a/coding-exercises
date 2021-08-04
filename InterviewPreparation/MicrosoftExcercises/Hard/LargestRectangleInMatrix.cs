using System;
using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Hard
{
    class LargestRectangleInMatrix
    {
        public class Solution
        {
            public int MaximalRectangle(char[][] matrix)
            {
                if (matrix == null)
                    return 0;
                var rows = matrix.Length;

                if (rows == 0)
                {
                    return 0;
                }

                int columns = matrix[0].Length;
                var heights = new int[columns + 1];

                int max = 0;
                foreach (char[] row in matrix)
                {
                    for (int col = 0; col < columns; col++)
                    {
                        if (row[col] == '1')
                        {
                            heights[col] += 1;
                        }
                        else
                        {
                            heights[col] = 0;
                        }
                    }

                    max = Math.Max(max, CalculateMaximumRectangleInHistogram(heights));
                }

                return max;
            }

            private int CalculateMaximumRectangleInHistogram(int[] histogram)
            {
                var length = histogram.Length;
                var stack = new Stack<int>();

                int max = 0;
                for (int i = 0; i < length; i++)
                {
                    var current = histogram[i];
                    int h = (i == length) ? 0 : current;

                    while (stack.Count > 0 && histogram[stack.Peek()] > h)
                    {
                        int index = stack.Pop();

                        int leftBound = -1;
                        if (stack.Count > 0)
                        {
                            leftBound = stack.Peek();
                        }

                        max = Math.Max(max, histogram[index] * (i - leftBound - 1));
                    }

                    stack.Push(i);
                }

                return max;
            }
        }
    }
}
