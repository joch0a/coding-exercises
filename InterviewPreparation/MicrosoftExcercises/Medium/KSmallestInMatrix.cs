using System;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class KSmallestInMatrix
    {
        // Kinda shitty sol
        public int KthSmallest(int[][] matrix, int k)
        {
            var sorted = new int[matrix.Length * matrix[0].Length];
            var sortedIndex = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    sorted[sortedIndex++] = matrix[i][j];
                }
            }

            Array.Sort(sorted);

            return sorted[k - 1];
        }
    }
}
