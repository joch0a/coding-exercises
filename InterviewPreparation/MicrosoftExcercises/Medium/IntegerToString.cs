using System;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class IntegerToString
    {
        public int MyAtoi(string s)
        {
            var result = 0;
            int i = 0;
            int sign = 1;


            //search for sign ignore zeroes
            while (i < s.Length && s[i] != '-' && s[i] != '+' && s[i] != '0' && !char.IsDigit(s[i]))
            {
                if (s[i] != '-' && s[i] != '+' && !char.IsDigit(s[i]) && s[i] != ' ')
                {
                    return 0;
                }

                i++;
            }

            if (i == s.Length || (!char.IsDigit(s[i]) && s[i] != '-' && s[i] != '+'))
            {
                return 0;
            }

            if (s[i] == '-' || s[i] == '+')
            {
                sign = s[i] == '-' ? -1 : 1;

                i++;
            }

            var lastPositiveDigit = int.MaxValue % 10;
            var lastNegativeDigit = Math.Abs(int.MinValue % 10);

            while (i < s.Length && char.IsDigit(s[i]))
            {
                var digit = int.Parse(s[i].ToString());

                if (sign == 1)
                {
                    if (result > int.MaxValue / 10 || (result == int.MaxValue / 10 && digit > lastPositiveDigit))
                    {
                        return int.MaxValue;
                    }
                }
                else
                {
                    if (result * -1 < int.MinValue / 10 ||
                        (result == int.MaxValue / 10 && digit > lastNegativeDigit))
                    {
                        return int.MinValue;
                    }
                }

                result = result * 10 + digit;

                i++;
            }

            return result * sign;
        }
    }
}
