namespace InterviewPreparation.TrainExercises.Easy
{
    class CountBinarySubStrings
    {
        public int CountBinarySubstrings(string s)
        {
            var lastConsecutiveCount = 1;
            var consecutiveCount = 1;
            var total = 0;

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] != s[i - 1])
                {
                    lastConsecutiveCount = consecutiveCount;
                    consecutiveCount = 1;
                    total++;
                }
                else
                {
                    consecutiveCount++;
                    if (consecutiveCount <= lastConsecutiveCount)
                    {
                        total++;
                    }
                }
            }

            return total;
        }
    }
}
