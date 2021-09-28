using System;

namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class NumberOfBalloons
    {
        public int MaxNumberOfBalloons(string text)
        {
            var pattern = "balloon";
            var freqText = BuildFrequency(text);
            var freqPattern = BuildFrequency(pattern);
            var total = int.MaxValue;

            for (int i = 0; i < 26; i++)
            {
                if (freqPattern[i] > 0)
                {
                    total = Math.Min(total, freqText[i] / freqPattern[i]);
                }
            }

            return total;
        }

        private int[] BuildFrequency(string str)
        {
            var freq = new int[26];

            foreach (var currentChar in str)
            {
                freq[currentChar - 'a']++;
            }

            return freq;
        }
    }
}
