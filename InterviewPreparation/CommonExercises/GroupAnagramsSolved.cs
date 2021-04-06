using System.Collections.Generic;

namespace InterviewPreparation.Exercises
{
    class GroupAnagramsSolved
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var anagrams = new List<IList<string>>();
            var visited = new HashSet<int>();
            var buckets = new List<KeyValuePair<string, int[]>>();

            foreach (var str in strs)
            {
                var actualBucket = new int[27];

                for (var i = 0; i < str.Length; i++)
                {
                    actualBucket[str[i] - 'a']++;
                }

                buckets.Add(new KeyValuePair<string, int[]>(str, actualBucket));
            }

            for (int i = 0; i < buckets.Count; i++)
            {
                var keyPair = buckets[i];

                if (!visited.Contains(i))
                {
                    var groupAnagram = new List<string>();
                    groupAnagram.Add(keyPair.Key);

                    visited.Add(i);

                    for (int j = i + 1; j < buckets.Count; j++)
                    {
                        var actualKeyPair = buckets[j];

                        if (!visited.Contains(j) && IsAnagram(keyPair.Value, actualKeyPair.Value))
                        {
                            groupAnagram.Add(actualKeyPair.Key);
                            visited.Add(j);
                        }
                    }

                    anagrams.Add(groupAnagram);
                }
            }

            return anagrams;
        }

        private bool IsAnagram(int[] bucket1, int[] bucket2)
        {
            for (int i = 0; i < bucket1.Length; i++)
            {
                if (bucket1[i] != bucket2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
