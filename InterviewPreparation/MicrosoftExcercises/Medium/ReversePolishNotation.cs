using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class ReversePolishNotation
    {
        public int EvalRPN(string[] tokens)
        {
            var stack = new Stack<int>();

            foreach (var token in tokens)
            {
                if (token == "+" || token == "-" || token == "*" || token == "/")
                {
                    var num2 = stack.Pop();
                    var num1 = stack.Pop();

                    int result;

                    if (token == "+")
                    {
                        result = num1 + num2;
                    }

                    else if (token == "-")
                    {
                        result = num1 - num2;
                    }

                    else if (token == "*")
                    {
                        result = num1 * num2;
                    }

                    else // token == "/"
                    {
                        result = num1 / num2;
                    }

                    stack.Push(result);
                }
                else
                {
                    stack.Push(int.Parse(token));
                }
            }

            return stack.Pop();
        }
    }
}
