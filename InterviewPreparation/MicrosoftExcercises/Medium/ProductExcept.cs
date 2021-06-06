namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    // Product of Array Except Self
    class ProductExcept
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            var left = new int[nums.Length];
            var right = new int[nums.Length];

            left[0] = 1;

            for (int i = 1; i < left.Length; i++)
            {
                left[i] = left[i - 1] * nums[i - 1];
            }

            right[right.Length - 1] = 1;

            for (int i = right.Length - 2; i >= 0; i--)
            {
                right[i] = right[i + 1] * nums[i + 1];
            }

            var result = new int[nums.Length];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = left[i] * right[i];
            }

            return result;
        }
    }
}
