using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class WordPattern
    {
        public bool Solve(string pattern, string s)
        {
            var dictPattern = new Dictionary<char, string>();
            var dictWords = new Dictionary<string, char>();
            var words = s.Split(' ');

            if (words.Length != pattern.Length)
            {
                return false;
            }

            for (int i = 0; i < words.Length; i++)
            {
                if (!dictPattern.ContainsKey(pattern[i]) && !dictWords.ContainsKey(words[i]))
                {
                    dictPattern.Add(pattern[i], words[i]);
                    dictWords.Add(words[i], pattern[i]);
                }
                else if (dictPattern.ContainsKey(pattern[i]) && dictWords.ContainsKey(words[i]))
                {
                    if (dictPattern[pattern[i]] != words[i] || dictWords[words[i]] != pattern[i])
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
