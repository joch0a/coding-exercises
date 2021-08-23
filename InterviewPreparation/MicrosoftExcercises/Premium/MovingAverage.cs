using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Premium
{
    class MovingAverage
    {

        private LinkedList<int> stream;
        private int maxSize;
        private double totalSum;

        /** Initialize your data structure here. */
        public MovingAverage(int size)
        {
            stream = new LinkedList<int>();
            maxSize = size;
            totalSum = 0;
        }

        public double Next(int val)
        {
            if (stream.Count == maxSize)
            {
                totalSum -= stream.First.Value;
                stream.RemoveFirst();
            }

            totalSum += val;

            stream.AddLast(val);

            return totalSum / (stream.Count * 1.0);
        }
    }
}
