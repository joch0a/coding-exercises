namespace InterviewPreparation.TrainExercises.Easy
{
    class ValidAnagrams
    {
        public bool IsAnagram(string s, string t)
        {
            int[] bucket = new int[26];

            foreach (var character in s)
            {
                bucket[character - 'a']++;
            }

            foreach (var character in t)
            {
                bucket[character - 'a']--;
            }

            foreach (var b in bucket)
            {
                if (b != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
