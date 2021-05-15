namespace InterviewPreparation.TrainExercises.Easy
{
    public class Solution
    {
        public int[] Shuffle(int[] nums, int n)
        {
            int[] shuffle = new int[nums.Length];

            var i = 0;
            var j = nums.Length / 2;
            int x = 0;

            while (x < nums.Length)
            {
                shuffle[x] = nums[i];
                x++;
                i++;
                if (x < nums.Length)
                {
                    shuffle[x] = nums[j];
                    x++;
                    j++;
                }
            }

            return shuffle;
        }
    }
}