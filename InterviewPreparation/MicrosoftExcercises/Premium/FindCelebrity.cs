using System;

namespace InterviewPreparation.MicrosoftExcercises.Premium
{
    class FindCelebrity
    {
        public int Solve(int n)
        {
            var candidate = 0;

            for (int i = 1; i < n; i++)
            {
                if (Knows(candidate, i))
                {
                    candidate = i;
                }
            }

            return CheckCelebrity(n, candidate);
        }

        private bool Knows(int candidate, int i)
        {
            throw new NotImplementedException();
        }

        private int CheckCelebrity(int totalCandidates, int candidate)
        {
            for (int i = 0; i < totalCandidates; i++)
            {
                if (i == candidate)
                {
                    continue;
                }

                if (!Knows(i, candidate) || Knows(candidate, i))
                {
                    return -1;
                }
            }

            return candidate;
        }
    }
}
