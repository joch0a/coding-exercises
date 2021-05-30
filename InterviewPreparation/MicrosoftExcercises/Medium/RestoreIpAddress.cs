using System.Collections.Generic;
using System.Text;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class RestoreIpAddress
    {
        public IList<string> result;

        public IList<string> RestoreIpAddresses(string s)
        {
            result = new List<string>();
            var actualIp = new string[4];

            if (s.Length < 4)
            {
                return result;
            }

            Backtrack(s, actualIp, 0, 0);

            return result;
        }

        public void Backtrack(string s, string[] actualIp, int buildIndex, int bucket)
        {
            if (bucket == 4 && buildIndex == s.Length)
            {
                result.Add(string.Join(".", actualIp));
                return;
            }
            else if (bucket == 4 || buildIndex == s.Length)
            {
                return;
            }

            var actualNumber = new StringBuilder();

            for (int len = 0; len < 3 && len + buildIndex < s.Length; len++)
            {
                actualNumber.Append(s[buildIndex + len]);

                if (IsValid(actualNumber.ToString()))
                {
                    actualIp[bucket] = actualNumber.ToString();

                    Backtrack(s, actualIp, len + buildIndex + 1, bucket + 1);

                    actualIp[bucket] = "-1";
                }
            }
        }

        public bool IsValid(string number)
        {
            var num = int.Parse(number);

            if (num > 255 || num.ToString().Length != number.Length)
            {
                return false;
            }

            return true;
        }
    }
}
