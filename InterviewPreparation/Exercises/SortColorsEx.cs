namespace InterviewPreparation.Exercises
{
    class SortColorsEx
    {
        public void SortColors(int[] nums)
        {
            var left = 0;
            var medium = 0;
            var right = nums.Length - 1;

            while (medium <= right)
            {
                if (nums[medium] == 0)
                {
                    Swap(nums, left, medium);
                    left++;
                    medium++;
                }

                else if (nums[medium] == 1)
                {
                    medium++;
                }

                else if (nums[medium] == 2)
                {
                    Swap(nums, medium, right);
                    right--;
                }
            }
        }

        private void Swap(int[] nums, int i, int j)
        {
            var aux = nums[i];
            nums[i] = nums[j];
            nums[j] = aux;
        }
    }
}
