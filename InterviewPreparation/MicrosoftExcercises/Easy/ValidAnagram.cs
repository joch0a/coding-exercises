namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class ValidAnagram
    {
        public bool IsAnagram(string s, string t)
        {
            var bucket = new int[26];

            for (int i = 0; i < s.Length; i++)
            {
                bucket[s[i] - 'a']++;
            }

            for (int i = 0; i < t.Length; i++)
            {
                bucket[t[i] - 'a']--;
            }


            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i] != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
