namespace InterviewPreparation.CommonExercises.Hard_Array
{
    class FindDuplicate
    {
        public int Solve(int[] nums)
        {
            var slow = 0;
            var fast = 0;

            while (fast < nums.Length && nums[fast] < nums.Length)
            {
                fast = nums[nums[fast]];
                slow = nums[slow];

                if (fast == slow)
                {
                    break;
                }
            }

            slow = 0;

            while (slow != fast)
            {
                slow = nums[slow];
                fast = nums[fast];
            }

            return slow;
        }
    }
}
