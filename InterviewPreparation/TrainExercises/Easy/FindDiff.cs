namespace InterviewPreparation.TrainExercises.Easy
{
    class FindDiff
    {
        // https://leetcode.com/problems/find-the-difference/
        public char FindTheDifference(string s, string t)
        {
            var bucket = new int[26];

            foreach (var c in s)
            {
                bucket[c - 'a']++;
            }

            foreach (var c in t)
            {
                bucket[c - 'a']--;
            }

            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i] != 0)
                {
                    return (char)(i + 'a');
                }
            }

            return 'a';
        }
    }
}
