namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class MyPow
    {
        public double Solve(double x, int n)
        {
            if (n < 0) return 1 / x * Solve(1 / x, -(n + 1));
            if (n == 0) return 1;
            if (n == 1) return x;
            if (n % 2 == 0) return Solve(x * x, n / 2);
            return x * Solve(x * x, n / 2);
        }
    }
}
