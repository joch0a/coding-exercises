namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class RangeSumQuery2D
    {
        private int[,] prefixes;

        public NumMatrix(int[][] matrix)
        {
            if (matrix.Length == 0 || matrix[0].Length == 0) return;

            prefixes = new int[matrix.Length + 1, matrix[0].Length + 1];

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    prefixes[i + 1, j + 1] = prefixes[i + 1, j] + prefixes[i, j + 1]
                        + matrix[i][j] - prefixes[i, j];
                }
            }
        }

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            return
                prefixes[row2 + 1, col2 + 1]
                - prefixes[row1, col2 + 1]
                + prefixes[row1, col1]
                - prefixes[row2 + 1, col1];
        }
    }
}
