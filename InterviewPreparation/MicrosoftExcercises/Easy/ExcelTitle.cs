using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class ExcelTitle
    {
        public string ConvertToTitle(int columnNumber)
        {
            var sb = new StringBuilder();
            var stack = new Stack<char>();

            while (columnNumber > 0)
            {
                columnNumber--;
                stack.Push((char)(columnNumber % 26 + 'A'));
                columnNumber /= 26;
            }

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Peek());
                sb.Append(stack.Pop());
            }

            return sb.ToString();
        }
    }
}
