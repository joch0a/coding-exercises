namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class FirstUniqueCharInString
    {
        public int FirstUniqChar(string s)
        {
            var bucket = new int[26];

            for (int i = 0; i < s.Length; i++)
            {
                bucket[s[i] - 'a']++;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (bucket[s[i] - 'a'] == 1)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
