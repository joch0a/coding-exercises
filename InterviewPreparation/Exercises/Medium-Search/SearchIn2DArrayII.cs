namespace InterviewPreparation.Exercises.Search
{
    class SearchIn2DArrayII
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {
            if (matrix == null || matrix.Length == 0)
            {
                return false;
            }

            var i = 0;
            var j = matrix[0].Length - 1;

            while (i <= matrix.Length - 1 && j >= 0)
            {
                if (matrix[i][j] == target)
                {
                    return true;
                }
                else if (target < matrix[i][j])
                {
                    j--;
                }
                else
                {
                    i++;
                }
            }

            return false;
        }
    }
}
