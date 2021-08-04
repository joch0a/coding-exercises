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

        public int[] SortArrayByParityInPlace(int[] nums)
        {
            var evens = 0;
            var odds = nums.Length - 1;

            while (evens < odds)
            {
                if (nums[evens] % 2 == 0)
                {
                    evens++;
                }
                else
                {
                    var tmp = nums[evens];
                    nums[evens] = nums[odds];
                    nums[odds] = tmp;

                    odds--;
                }
            }

            return nums;
        }
    }
}
