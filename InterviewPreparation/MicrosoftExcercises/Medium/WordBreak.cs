using System.Collections.Generic;
using System.Linq;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    public class WordBreakEx
    {

        public Dictionary<string, bool> Cache = new Dictionary<string, bool>();
        public HashSet<string> wordSet;

        public bool WordBreak(string str, IList<string> words)
        {
            wordSet = words.ToHashSet();

            return WordBreak(str);
        }

        private bool WordBreak(string str)
        {
            if (wordSet.Contains(str))
            {
                return true;
            }

            if (Cache.ContainsKey(str))
            {
                return Cache[str];
            }

            for (int i = 1; i <= str.Length; i++)
            {
                var left = str.Substring(0, i);

                if (wordSet.Contains(left) && WordBreak(str.Substring(i)))
                {
                    Cache.Add(str, true);

                    return true;
                }
            }

            Cache.Add(str, false);

            return false;
        }
    }

    public class FirstApproachTLE
    {
        public Dictionary<string, int> dict = new Dictionary<string, int>();
        public bool result = false;

        public bool WordBreak(string str, IList<string> words)
        {
            foreach (var word in words)
            {
                if (!dict.ContainsKey(word))
                {
                    dict.Add(word, 0);
                }
            }

            Backtrack(str, 0, "");

            return result;
        }

        public void Backtrack(string str, int index, string currentWord)
        {
            int i;

            for (i = 0; i < currentWord.Length; i++)
            {
                if (str[index + i] != currentWord[i])
                {
                    break;
                }
            }

            if (index + i == str.Length)
            {
                foreach (var tuple in dict)
                {
                    if (tuple.Value > 0)
                    {
                        result = true;

                        return;
                    }
                }
            }

            if (i == currentWord.Length)
            {
                foreach (var word in dict.Keys.ToList())
                {
                    if (index + i < str.Length && str[index + i] == word[0] && index + i + word.Length - 1 <= str.Length - 1)
                    {
                        dict[word] += 1;

                        Backtrack(str, index + i, word);

                        dict[word] -= 1;
                    }
                }
            }
        }
    }
}
