using System;
using System.Linq;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class RandomPickWithWeight
    {
        private int[] _weightSum;
        private Random _rnd = new Random();

        public RandomPickWithWeight(int[] w)
        {
            _weightSum = new int[w.Length];
            int max = 0;
            for (int i = 0; i < w.Length; i++)
            {
                max += w[i];
                _weightSum[i] = max;
            }
        }

        public int PickIndex()
        {
            int randomWeight = _rnd.Next(0, _weightSum.Last()) + 1;

            int low = 0;
            int high = _weightSum.Length - 1;

            while (low <= high)
            {
                var mid = low + (high - low) / 2;

                if (_weightSum[mid] == randomWeight)
                {
                    return mid;
                }
                else if (_weightSum[mid] > randomWeight)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return low;
        }
    }
}
