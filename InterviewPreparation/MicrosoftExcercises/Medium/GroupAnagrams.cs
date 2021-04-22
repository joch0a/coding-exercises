using System.Collections.Generic;
using System.Text;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class GroupAnagrams
    {
        public IList<IList<string>> Solve(string[] strs)
        {
            var result = new List<IList<string>>();

            var dictionary = new Dictionary<string, List<string>>();

            foreach (var str in strs)
            {
                var actualAnagram = CalculateAnagram(str);

                if (dictionary.ContainsKey(actualAnagram))
                {
                    dictionary[actualAnagram].Add(str);
                }
                else
                {
                    dictionary.Add(actualAnagram, new List<string>() { str });
                }
            }

            return new List<IList<string>>(dictionary.Values);
        }

        public string CalculateAnagram(string str)
        {
            var bucket = new int[26];

            foreach (var s in str)
            {
                bucket[s - 'a']++;
            }

            var sb = new StringBuilder();

            foreach (var b in bucket)
            {
                sb.Append($"{b}#");
            }

            return sb.ToString();
        }
    }
}
