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

        //follow up
        public bool Solve2(int x)
        {
            if (x < 0 || (x % 10 == 0 && x != 0))
            {
                return false;
            }

            var reversed = 0;

            while (x > reversed)
            {
                reversed = (10 * reversed) + x % 10;
                x = x / 10;
            }

            return reversed == x || reversed / 10 == x;
        }
    }
}
