namespace InterviewPreparation.CommonExercises.Easy_String
{
    class Palindrome
    {
        public bool IsPalindrome(string s)
        {
            int i = 0;
            int j = s.Length - 1;

            while (i < j)
            {
                while (i < j && !char.IsDigit(s[i]) && !char.IsLetter(s[i]))
                {
                    i++;
                }
                while (i < j && !char.IsDigit(s[j]) && !char.IsLetter(s[j]))
                {
                    j--;
                }

                if (i < j && char.ToLower(s[i]) != char.ToLower(s[j]))
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
