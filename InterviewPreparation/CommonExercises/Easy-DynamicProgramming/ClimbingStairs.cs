namespace InterviewPreparation.CommonExercises.Easy_DynamicProgramming
{
    class ClimbingStairs
    {
        public int ClimbStairs(int n)
        {
            if (n == 1)
            {
                return 1;
            }

            if (n == 2)
            {
                return 2;
            }

            var arr = new int[n];

            arr[0] = 1;
            arr[1] = 2;

            for (int i = 2; i < n; i++)
            {
                arr[i] = arr[i - 1] + arr[i - 2];
            }

            return arr[n - 1];
        }
    }
}
