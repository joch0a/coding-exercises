namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class ReverseString
    {
        public void Solve(char[] s)
        {
            int i = 0;
            int j = s.Length - 1;
            char tmp;

            while (i < j)
            {
                tmp = s[i];
                s[i] = s[j];
                s[j] = tmp;

                i++;
                j--;
            }
        }
    }
}
