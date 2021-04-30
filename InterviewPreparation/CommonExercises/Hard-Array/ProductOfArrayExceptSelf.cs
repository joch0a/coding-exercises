namespace InterviewPreparation.CommonExercises.Hard_Array
{
    class ProductOfArrayExceptSelf
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            var result = new int[nums.Length];

            result[0] = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                result[i] = result[i - 1] * nums[i - 1];
            }

            var right = 1;

            for (int i = nums.Length - 2; i >= 0; i--)
            {
                right = right * nums[i + 1];
                result[i] = result[i] * right;
            }

            return result;
        }
    }
}
