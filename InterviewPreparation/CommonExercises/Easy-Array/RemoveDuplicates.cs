namespace InterviewPreparation.CommonExercises.Easy_Array
{
    class RemoveDuplicatesFromSortedArray

    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length < 2)
            {
                return nums.Length;
            }

            var leftPosition = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0 || nums[i] != nums[i - 1])
                {
                    nums[leftPosition] = nums[i];
                    leftPosition++;
                }
            }

            return leftPosition;
        }
    }
}
