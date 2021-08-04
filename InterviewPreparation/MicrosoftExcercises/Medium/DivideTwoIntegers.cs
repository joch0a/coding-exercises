namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    public class DivideTwoIntegers
    {
        public int Divide(int dividend, int divisor)
        {
            // Handle edge cases
            if (dividend == 0)
            {
                return 0;
            }
            else if (dividend == int.MinValue && divisor == -1)
            {
                return int.MaxValue;
            }

            // Get sign and switch to negative
            var positive = true;
            if (dividend > 0)
            {
                dividend = -dividend;
                positive = !positive;
            }

            if (divisor > 0)
            {
                divisor = -divisor;
                positive = !positive;
            }

            int res = helper(dividend, divisor);
            return positive ? res : -res;
        }

        public int helper(int dividend, int divisor)
        {
            if (dividend > divisor)
            {
                return 0;
            }

            int multiple = divisor;
            int count = 1;
            while (multiple + multiple > dividend && multiple + multiple < 0)
            {
                count += count;
                multiple += multiple;
            }

            int leftOver = dividend - multiple;

            int res = count + helper(leftOver, divisor);

            return res;
        }
    }
}
