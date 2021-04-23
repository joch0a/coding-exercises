using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class RomanToInteger
    {
        public int RomanToInt(string s)
        {
            var number = 0;
            var dict = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

            for (int i = 0; i < s.Length; i++)
            {
                var actual = s[i];

                if (i < s.Length - 1 && dict[actual] < dict[s[i + 1]])
                {
                    number -= dict[actual];
                }
                else
                {
                    number += dict[actual];
                }
            }

            return number;
        }
    }
}
