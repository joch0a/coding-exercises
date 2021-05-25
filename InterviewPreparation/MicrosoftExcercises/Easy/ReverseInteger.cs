namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class ReverseInteger
    {
        public int Reverse(int x)
        {
            var lastPositiveDigit = int.MaxValue % 10;
            var lastNegativeDigit = int.MinValue % 10;

            var rev = 0;

            while (x != 0)
            {
                var digit = x % 10;

                if (rev > int.MaxValue / 10 || (rev == int.MaxValue && digit > lastPositiveDigit))
                {
                    return 0;
                }

                if (rev < int.MinValue / 10 || (rev == int.MinValue && digit > lastNegativeDigit))
                {
                    return 0;
                }

                rev = rev * 10 + digit;

                x /= 10;
            }

            return rev;
        }
    }
}
