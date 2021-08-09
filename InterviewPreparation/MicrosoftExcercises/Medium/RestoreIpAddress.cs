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


public class RestoreIpAddresses
{
    public IList<string> RestoreIpAddressesReview(string s)
    {
        var restored = new List<string>();
        if (s.Length < 4 || s.Length > 12)
        {
            return restored;
        }
        Backtrack(s, 0, 0, new string[4], restored);
        return restored;
    }
    public void Backtrack(string str, int start, int blockCount, string[] blocks, List<string> restored)
    {
        if (blockCount == 4)
        {
            if (str.Length == start)
            {
                var ip = new StringBuilder();
                foreach (var block in blocks)
                {
                    ip.Append($"{block}.");
                }
                ip.Length -= 1;
                restored.Add(ip.ToString());
            }
            return;
        }
        string currentBlock = "";
        for (int i = 0; i < 4 && start + i < str.Length; i++)
        {
            currentBlock += str[start + i];
            if (isValid(currentBlock))
            {
                blocks[blockCount] = currentBlock;
                Backtrack(str, start + i + 1, blockCount + 1, blocks, restored);
                blocks[blockCount] = "";
            }
        }
    }
    private bool isValid(string block)
    {
        var num = int.Parse(block);

        return num >= 0 && num <= 255 && num.ToString().Length == block.Length;
    }
}