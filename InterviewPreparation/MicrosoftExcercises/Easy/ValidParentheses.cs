using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class ValidParentheses
    {
        public bool IsValid(string s)
        {
            var stack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case '(':
                        stack.Push('(');
                        break;
                    case '{':
                        stack.Push('{');
                        break;
                    case '[':
                        stack.Push('[');
                        break;
                    case ')':
                        if (stack.Count == 0 || stack.Pop() != '(')
                        {
                            return false;
                        }
                        break;
                    case '}':
                        if (stack.Count == 0 || stack.Pop() != '{')
                        {
                            return false;
                        }
                        break;
                    case ']':
                        if (stack.Count == 0 || stack.Pop() != '[')
                        {
                            return false;
                        }
                        break;
                }
            }

            return stack.Count == 0;
        }

        public bool IsValidOptimized(string s)
        {
            var mapping = new Dictionary<char, char>()
            {
                {'}', '{'},
                {')', '('},
                {']', '['}
            };

            var stack = new Stack<char>();

            foreach (var c in s)
            {
                if (!mapping.ContainsKey(c))
                {
                    stack.Push(c);
                }
                else
                {
                    if (stack.Count == 0 || stack.Pop() != mapping[c])
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }
    }
}
