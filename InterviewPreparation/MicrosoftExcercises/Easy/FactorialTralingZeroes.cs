namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class FactorialTralingZeroes
    {
        public int TrailingZeroes(int n)
        {
            var total = 0;

            while (n > 0)
            {
                total = n / 5 + total;
                n = n / 5;
            }

            return total;
        }
    }
