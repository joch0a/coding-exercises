using System.Collections.Generic;
using System.Linq;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class TopKFrequentWords
    {
        public IList<string> TopKFrequent(string[] words, int k)
        {
            var frequencies = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (frequencies.ContainsKey(word))
                {
                    frequencies[word] += 1;
                }
                else
                {
                    frequencies.Add(word, 1);
                }
            }

            return frequencies.OrderByDescending(key => key.Value)
                .ThenBy(key => key.Key)
                .Take(k)
                .Select(key => key.Key)
                .ToList();
        }
    }
}
