namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class MoveZeroes
    {
        public void Solve(int[] nums)
        {
            var leftPosition = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[leftPosition] = nums[i];
                    if (i != leftPosition)
                    {
                        nums[i] = 0;
                    }

                    leftPosition++;
                }
            }
        }
    }
}
