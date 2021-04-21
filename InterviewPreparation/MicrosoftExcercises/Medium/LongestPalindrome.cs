namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class LongestPalindrome
    {
        public string Solve(string s)
        {
            var maxPalindrome = "";
            for (int i = 0; i < s.Length; i++)
            {
                var p1 = CalculatePalindrome(s, i, i);
                var p2 = CalculatePalindrome(s, i, i + 1);

                maxPalindrome = maxPalindrome.Length > p1.Length ? maxPalindrome : p1;
                maxPalindrome = maxPalindrome.Length > p2.Length ? maxPalindrome : p2;
            }
            return maxPalindrome;
        }
        public string CalculatePalindrome(string s, int i, int j)
        {
            while (i >= 0 && j < s.Length && s[i] == s[j])
            {
                i--;
                j++;
            }
            return s.Substring(i + 1, j - i - 1);
        }
    }
}
