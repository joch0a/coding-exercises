using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    public class MyStack
    {
        private Queue<int> stack;
        private Queue<int> queue;

        /** Initialize your data structure here. */
        public MyStack()
        {
            queue = new Queue<int>();
            stack = new Queue<int>();
        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
            queue.Enqueue(x);

            while (stack.Count > 0)
            {
                queue.Enqueue(stack.Dequeue());
            }


            while (queue.Count > 0)
            {
                stack.Enqueue(queue.Dequeue());
            }
        }

        /** Removes the element on top of the stack and returns that element. */
        public int Pop()
        {
            return stack.Dequeue();
        }

        /** Get the top element. */
        public int Top()
        {
            return stack.Peek();
        }

        /** Returns whether the stack is empty. */
        public bool Empty()
        {
            return stack.Count == 0;
        }
    }
}
