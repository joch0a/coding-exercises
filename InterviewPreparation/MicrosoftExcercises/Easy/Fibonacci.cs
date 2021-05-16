namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class Fibonacci
    {
        public int Fib(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n == 1 || n == 2)
            {
                return 1;
            }

            var f1 = 0;
            var f2 = 1;
            int next;

            for (int i = 1; i < n; i++)
            {
                next = f1 + f2;
                f1 = f2;
                f2 = next;
            }

            return f2;
        }
    }
}
