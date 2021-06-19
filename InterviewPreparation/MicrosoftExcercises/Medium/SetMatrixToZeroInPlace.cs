namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class SetMatrixToZeroInPlace
    {
        public void SetZeroes(int[][] matrix)
        {
            var firstColumn = false;

            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i][0] == 0)
                {
                    firstColumn = true;
                }

                for (int j = 1; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[i][0] = 0;
                        matrix[0][j] = 0;
                    }
                }
            }

            for (int i = 1; i < matrix.Length; i++)
            {
                for (int j = 1; j < matrix[i].Length; j++)
                {
                    if (matrix[i][0] == 0 || matrix[0][j] == 0)
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

            if (firstColumn)
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    matrix[i][0] = 0;
                }
            }
        }
    }
}
