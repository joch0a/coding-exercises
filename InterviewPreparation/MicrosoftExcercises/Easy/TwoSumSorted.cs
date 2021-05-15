namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class TwoSumSorted
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            var i = 0;
            var j = numbers.Length - 1;

            while (i < j)
            {
                if (numbers[i] + numbers[j] == target)
                {
                    return new int[] { i + 1, j + 1 };
                }
                else if (numbers[i] + numbers[j] > target)
                {
                    j--;
                }
                else
                {
                    i++;
                }
            }

            return null;
        }
    }
}
