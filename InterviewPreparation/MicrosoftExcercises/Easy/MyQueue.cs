using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    public class MyQueue
    {

        public Stack<int> stack { get; set; }
        public Stack<int> queue { get; set; }


        /** Initialize your data structure here. */
        public MyQueue()
        {
            stack = new Stack<int>();
            queue = new Stack<int>();
        }

        /** Push element x to the back of queue. */
        public void Push(int x)
        {
            while (queue.Count > 0)
            {
                stack.Push(queue.Pop());
            }

            stack.Push(x);

            while (stack.Count > 0)
            {
                queue.Push(stack.Pop());
            }
        }

        /** Removes the element from in front of queue and returns that element. */
        public int Pop()
        {
            return queue.Pop();
        }

        /** Get the front element. */
        public int Peek()
        {
            return queue.Peek();
        }

        /** Returns whether the queue is empty. */
        public bool Empty()
        {
            return queue.Count == 0;
        }
    }
}
