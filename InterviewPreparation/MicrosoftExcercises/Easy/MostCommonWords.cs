using System.Collections.Generic;
using System.Text;

namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class MostCommonWords
    {
        public string MostCommonWord(string paragraph, string[] banned)
        {
            paragraph = paragraph.ToLower();
            var bannedHash = new HashSet<string>(banned);
            var max = "";
            var maxFreq = 0;
            var dict = new Dictionary<string, int>();
            var word = new StringBuilder();

            for (int i = 0; i < paragraph.Length; i++)
            {
                if (!char.IsLetter(paragraph[i]))
                {
                    var actual = word.ToString();

                    if (actual.Length > 0 && !bannedHash.Contains(actual))
                    {
                        if (!dict.ContainsKey(actual))
                        {
                            dict.Add(actual, 0);
                        }

                        dict[actual]++;

                        if (dict[actual] > maxFreq)
                        {
                            maxFreq = dict[actual];
                            max = actual;
                        }
                    }

                    word = new StringBuilder();
                }
                else
                {
                    word.Append(paragraph[i]);
                }
            }

            var actual1 = word.ToString();

            if (actual1.Length > 0 && !bannedHash.Contains(actual1))
            {
                if (!dict.ContainsKey(actual1))
                {
                    dict.Add(actual1, 0);
                }

                dict[actual1]++;

                if (dict[actual1] > maxFreq)
                {
                    maxFreq = dict[actual1];
                    max = actual1;
                }
            }

            return max;
        }
    }
}
