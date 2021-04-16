using System.Collections.Generic;
using System.Linq;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class RemoveKDigits
    {
        public string RemoveKdigits(string nums, int k)
        {
            var stack = new Stack<char>();

            foreach (var num in nums)
            {
                while (stack.Count > 0 && num < stack.Peek() && k > 0)
                {
                    stack.Pop();
                    k--;
                }

                stack.Push(num);
            }

            while (k > 0)
            {
                stack.Pop();
                k--;
            }

            var list = new LinkedList<char>();

            while (stack.Count > 0)
            {
                list.AddFirst(stack.Pop());
            }

            int i = 0;

            while (i < list.Count && list.ElementAt(i) == '0')
            {
                list.Remove('0');
            }

            if (list.Count == 0)
            {
                return "0";
            }

            return new string(list.ToArray());
        }
    }
}
