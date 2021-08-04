namespace InterviewPreparation.MicrosoftExcercises.Hard
{
    class RegularExpressionMatching
    {
        public bool IsMatch(string text, string pattern)
        {
            var dp = new bool?[text.Length + 1, pattern.Length + 1];

            return IsMatch(0, 0, text, pattern, dp);
        }

        private bool IsMatch(int i, int j, string text, string pattern, bool?[,] dp)
        {
            if (dp[i, j] != null)
            {
                return dp[i, j].Value;
            }

            bool result;

            if (j == pattern.Length)
            {
                result = i == text.Length;
            }
            else
            {
                var firstMatch = (i < text.Length && (text[i] == pattern[j] || pattern[j] == '.'));

                if (j + 1 < pattern.Length && pattern[j + 1] == '*')
                {
                    result = (IsMatch(i, j + 2, text, pattern, dp) || (firstMatch && IsMatch(i + 1, j, text, pattern, dp)));
                }
                else
                {
                    result = firstMatch && IsMatch(i + 1, j + 1, text, pattern, dp);
                }
            }

            dp[i, j] = result;

            return result;
        }
    }
}
