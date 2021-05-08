using System.Collections.Generic;

namespace InterviewPreparation.TrainExercises.Easy
{
    class SplitStringInBalancedStrings
    {
        public int BalancedStringSplit(string s)
        {
            var stack = new Stack<char>();
            var total = 0;
            var startsWithR = false;

            for (int i = 0; i < s.Length; i++)
            {
                var actual = s[i];

                if (stack.Count == 0)
                {
                    startsWithR = actual == 'R';
                }

                if (startsWithR)
                {
                    if (actual == 'R')
                    {
                        stack.Push(actual);
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
                else
                {
                    if (actual == 'L')
                    {
                        stack.Push(actual);
                    }
                    else
                    {
                        stack.Pop();
                    }
                }

                if (stack.Count == 0)
                {
                    total++;
                }
            }

            return total;
        }
    }
}
