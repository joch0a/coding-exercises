namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class SortByParity
    {
        public int[] SortArrayByParity(int[] nums)
        {
            var n = nums.Length;
            var result = new int[n];
            var evenIndex = 0;
            var oddIndex = n - 1;
            foreach (var num in nums)
            {
                if (num % 2 == 0)
                {
                    result[evenIndex++] = num;
                }
                else
                {
                    result[oddIndex--] = num;
                }
            }
            return result;
        }
    }
}
