using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class DecodeString
    {
        public int lastIndex = 0;
        public string DecodeStringSolve(string s)
        {
            return DecodeStringSolve(s, 0);
        }
        private string DecodeStringSolve(string s, int start)
        {
            var decoded = new StringBuilder();
            int currentIndex = start;
            while (currentIndex < s.Length)
            {
                var actual = s[currentIndex];
                if (char.IsLetter(actual))
                {
                    decoded.Append(actual);
                    currentIndex++;
                }
                else if (char.IsDigit(actual))
                {
                    var nextInteger = 0;
                    do
                    {
                        nextInteger = nextInteger * 10 + (int)(s[currentIndex] - '0');
                        currentIndex++;
                    } while (char.IsDigit(s[currentIndex]));
                    currentIndex++; // skip the [
                    var strInsideBrackets = DecodeStringSolve(s, currentIndex);
                    for (int i = 0; i < nextInteger; i++)
                    {
                        decoded.Append(strInsideBrackets);
                    }
                    currentIndex = lastIndex + 1;
                }
                else if (actual == ']')
                {
                    lastIndex = Math.Max(lastIndex, currentIndex);
                    return decoded.ToString();
                }
            }
            return decoded.ToString();
        }
    }
}
