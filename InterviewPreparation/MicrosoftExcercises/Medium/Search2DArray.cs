namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class Search2DArray
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {
            var i = matrix.Length - 1;
            var j = 0;

            while (i >= 0 && j < matrix[i].Length)
            {
                var actual = matrix[i][j];

                if (actual == target)
                {
                    return true;
                }
                else if (actual > target)
                {
                    i--;
                }
                else
                {
                    j++;
                }
            }

            return false;
        }
    }
}
