using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class SortCharactersByFrequency
    {
        public string FrequencySort(string str)
        {
            var frequencies = new Dictionary<char, int>();

            foreach (var character in str)
            {
                if (!frequencies.ContainsKey(character))
                {
                    frequencies.Add(character, 0);
                }

                frequencies[character]++;
            }

            var ordered = frequencies.OrderByDescending(tuple => tuple.Value);

            var sb = new StringBuilder();

            foreach (var tuple in ordered)
            {
                for (int i = 0; i < tuple.Value; i++)
                {
                    sb.Append(tuple.Key);
                }
            }

            return sb.ToString();
        }
    }
}
