namespace InterviewPreparation.CommonExercises.Easy_Array
{
    class SingleNumberInArray
    {
        public int SingleNumber(int[] nums)
        {
            int result = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                result = result ^ nums[i];
            }

            return result;
        }
    }
}
