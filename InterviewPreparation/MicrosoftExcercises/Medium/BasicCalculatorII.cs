using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class BasicCalculatorII
    {
        public int Calculate(string s)
        {
            var stack = new Stack<string>();
            char operation = '+';
            int i = 0;
            while (i < s.Length)
            {
                while (i < s.Length && s[i] == ' ')
                {
                    i++;
                }
                if (i < s.Length && (char.IsDigit(s[i]) || s[i] != ' '))
                {
                    int? actualNumber = null;
                    while (i < s.Length && char.IsDigit(s[i]))
                    {
                        if (actualNumber == null)
                        {
                            actualNumber = 0;
                        }
                        actualNumber = actualNumber * 10 + int.Parse(s[i].ToString());
                        i++;
                    }
                    if (operation == '+')
                    {
                        stack.Push(actualNumber.ToString());
                    }
                    else if (operation == '-')
                    {
                        stack.Push((-actualNumber).ToString());
                    }
                    else if (operation == '*')
                    {
                        stack.Push((actualNumber * int.Parse(stack.Pop())).ToString());
                    }
                    else if (operation == '/')
                    {
                        stack.Push((int.Parse(stack.Pop()) / actualNumber.Value).ToString());
                    }
                    if (i < s.Length)
                    {
                        operation = s[i];
                        i++;
                    }
                }
            }
            int result = 0;
            while (stack.Count > 0)
            {
                result += int.Parse(stack.Pop());
            }
            return result;
        }
    }
}
