namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class CompareVersion
    {
        public int Solve(string v1, string v2)
        {
            var p1 = 0;
            var p2 = 0;

            while (p1 < v1.Length || p2 < v2.Length)
            {
                var val1 = 0;
                var val2 = 0;

                while (p1 < v1.Length && v1[p1] != '.')
                {
                    val1 = val1 * 10 + v1[p1] - '0';
                    p1++;
                }

                while (p2 < v2.Length && v2[p2] != '.')
                {
                    val2 = val2 * 10 + v2[p2] - '0';
                    p2++;
                }

                if (val1 > val2)
                {
                    return 1;
                }
                else if (val1 < val2)
                {
                    return -1;
                }
                else
                {
                    p1++;
                    p2++;
                }
            }

            return 0;
        }
    }
}
