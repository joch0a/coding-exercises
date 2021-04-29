namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class IsPalindrome
    {
        public bool Solve(int x)
        {
            var str = x.ToString();
            int i = 0;
            int j = str.Length - 1;

            while (i <= j)
            {
                if (str[i] != str[j])
                {
                    return false;
                }

                i++;
                j--;
            }

            return true;
        }
    }
}
