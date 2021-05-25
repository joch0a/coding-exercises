using System;

namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class CountPrimes
    {
        public int Solve(int n)
        {
            var isPrime = new bool[n];

            var count = 0;

            for (int i = 2; i < n; i++)
            {
                isPrime[i] = true;
            }

            for (int i = 2; i < Math.Sqrt(n); i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * i; j < n; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }

            for (int i = 2; i < n; i++)
            {
                if (isPrime[i])
                {
                    count++;
                }
            }

            return count;
        }
    }
}
