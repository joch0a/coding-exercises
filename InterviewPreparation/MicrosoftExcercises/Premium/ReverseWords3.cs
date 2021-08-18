namespace InterviewPreparation.MicrosoftExcercises.Premium
{
    class ReverseWords3
    {
        public void ReverseWords(char[] s)
        {
            Reverse(s, 0, s.Length - 1);
            var index = 0;
            var left = 0;
            while (index <= s.Length)
            {
                while (index < s.Length && s[index] != ' ')
                {
                    index++;
                }
                Reverse(s, left, index - 1);
                index++;
                left = index;
            }
        }
        private void Reverse(char[] s, int left, int right)
        {
            while (left < right)
            {
                var aux = s[left];
                s[left] = s[right];
                s[right] = aux;
                left++;
                right--;
            }
        }
    }
}
