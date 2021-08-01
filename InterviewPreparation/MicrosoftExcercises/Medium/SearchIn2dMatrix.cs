namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    public class SearchIn2dMatrix
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {
            var m = matrix.Length;
            var n = matrix[0].Length;
            var low = 0;
            var high = (matrix.Length * matrix[0].Length) - 1;

            while (low <= high)
            {
                var mid = low + (high - low) / 2;
                var row = mid / n;
                var col = mid % n;

                if (matrix[row][col] == target)
                {
                    return true;
                }

                if (matrix[row][col] > target)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return false;
        }
    }
}
