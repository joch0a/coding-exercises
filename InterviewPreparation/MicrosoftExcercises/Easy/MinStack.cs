using System;
using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    public class MinStack
    {

        private LinkedList<int> minStack = new LinkedList<int>();
        private int min = int.MaxValue;

        /** initialize your data structure here. */
        public MinStack()
        {
            minStack = new LinkedList<int>();
            min = int.MaxValue;
        }

        public void Push(int x)
        {
            minStack.AddFirst(x);

            min = Math.Min(min, x);
        }

        public void Pop()
        {
            var firtValue = minStack.First.Value;
            minStack.RemoveFirst();

            if (min == firtValue)
            {
                min = int.MaxValue;

                foreach (var val in minStack)
                {
                    min = Math.Min(val, min);
                }
            }
        }

        public int Top()
        {
            return minStack.First.Value;
        }

        public int GetMin()
        {
            return min;
        }
    }
}
