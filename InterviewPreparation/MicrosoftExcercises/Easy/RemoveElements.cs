namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class RemoveElements
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length < 2)
            {
                return nums.Length;
            }
            var leftPosition = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[leftPosition] != nums[i])
                {
                    leftPosition++;
                    nums[leftPosition] = nums[i];
                }
            }

            return leftPosition + 1;
        }
    }
}
