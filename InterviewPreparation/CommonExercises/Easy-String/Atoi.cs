namespace InterviewPreparation.CommonExercises.Easy_String
{
    class Atoi
    {
        //https://leetcode.com/problems/string-to-integer-atoi/
        int result = 0;
        char actual;
        bool signFound = false;
        int sign;
        int i = 0;

        public int MyAtoi(string s)
        {
            if (s == null || s.Length == 0)
            {
                return 0;
            }


            //Find sign
            while (i < s.Length && !signFound)
            {
                actual = s[i];

                if (!ValidChar(actual))
                {
                    return result;
                }

                if (actual != ' ')
                {
                    signFound = true;
                }
                else
                {
                    i++;
                }
            }

            if (i >= s.Length)
            {
                return 0;
            }

            sign = s[i] == '-'
                ? -1
                : 1;


            if (!char.IsDigit(s[i]))
            {
                i++;
            }

            //Skip zeroes

            while (i < s.Length)
            {
                actual = s[i];

                if (char.IsDigit(actual) && actual != '0')
                {
                    break;
                }

                if (!ValidChar(actual))
                {
                    return result;
                }

                i++;
            }

            //Make number
            while (i < s.Length)
            {
                actual = s[i];

                if (char.IsDigit(actual))
                {
                    if (sign == 1)
                    {
                        if (result > int.MaxValue / 10 ||
                           (result == int.MaxValue / 10 && int.Parse(actual.ToString()) > 7))
                        {
                            return int.MaxValue;
                        }
                    }
                    else
                    {
                        if (result * -1 < int.MinValue / 10 ||
                           (result == int.MaxValue / 10 && int.Parse(actual.ToString()) > 8))
                        {
                            return int.MinValue;
                        }
                    }

                    result = result * 10 + int.Parse(actual.ToString());
                }

                if (!ValidChar(actual))
                {
                    return result * sign;
                }

                i++;
            }

            return result * sign;
        }

        private bool ValidChar(char c)
        {
            return char.IsDigit(c) ||
                (c == '+' && !signFound) ||
                (c == '-' && !signFound) ||
                (c == ' ' && !signFound);
        }
    }
}
