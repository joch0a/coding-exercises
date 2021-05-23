namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class SQRT
    {
        public int MySqrt(int x)
        {
            if (x == 0)
            {
                return 0;
            }

            long low = 1;
            long high = (int.MaxValue / 2) + 1;

            while (low < high)
            {
                long mid = low + (high - low) / 2;
                long result = mid * mid;

                if (result == x)
                {
                    return (int)mid;
                }
                else if (result > x)
                {
                    high = mid;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return (int)low - 1;
        }
    }
}
