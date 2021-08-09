namespace InterviewPreparation.MicrosoftExcercises.Hard
{
    class ValidNumber
    {
        public bool IsNumber(string str)
        {
            var numberSeen = false;
            var dotSeen = false;
            var eSeen = false;
            var numberAfterESeen = false;
            var index = 0;

            if (index < str.Length && IsSign(str[index]))
            {
                index++;
            }

            while (index < str.Length && char.IsDigit(str[index]))
            {
                numberSeen = true;
                index++;
            }

            if (index < str.Length && str[index] == '.')
            {
                dotSeen = true;
                index++;
            }

            while (index < str.Length && char.IsDigit(str[index]))
            {
                numberSeen = true;
                index++;
            }

            if (index < str.Length && (str[index] == 'e' || str[index] == 'E'))
            {
                eSeen = true;
                index++;
            }

            if (index < str.Length && IsSign(str[index]) && eSeen)
            {
                index++;
            }

            while (index < str.Length && char.IsDigit(str[index]) && eSeen)
            {
                numberAfterESeen = true;
                index++;
            }

            return index == str.Length &&
                (!dotSeen || dotSeen && numberSeen) &&
                eSeen == numberAfterESeen &&
                (!eSeen || eSeen && numberSeen);
        }

        private bool IsSign(char c)
        {
            return c == '+' || c == '-';
        }
    }
}
