using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Hard
{
    class BasicCalculator
    {
        public int Calculate(string s)
        {
            var stack = new Stack<int>();
            var sum = 0;
            var sign = 1;

            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s[i]))
                {
                    var num = 0;

                    do
                    {
                        num = num * 10 + (int)(s[i] - '0');
                        i++;
                    } while (i < s.Length && char.IsDigit(s[i]));
                    i--;
                    sum += sign * num;
                }
                else if (s[i] == '+')
                {
                    sign = 1;
                }
                else if (s[i] == '-')
                {
                    sign = -1;
                }
                else if (s[i] == '(')
                {
                    stack.Push(sum);
                    stack.Push(sign);
                    sum = 0;
                    sign = 1;
                }
                else if (s[i] == ')')
                {
                    sum = stack.Pop() * sum;
                    sum += stack.Pop();
                }
            }

            return sum;
        }
    }
}
