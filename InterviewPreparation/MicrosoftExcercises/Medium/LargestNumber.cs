using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class LargestNumber
    {
        public string Solve(int[] nums)
        {
            Array.Sort(nums, new MyComparer());
            var sb = new StringBuilder();

            foreach (var num in nums)
            {
                sb.Append(num);
            }

            var trailingIndex = 0;

            while (trailingIndex < sb.Length - 1 && sb[trailingIndex] == '0')
            {
                trailingIndex++;
            }

            return sb.ToString().Substring(trailingIndex);
        }
    }

    public class MyComparer : IComparer<int>
    {
        public int Compare(int a, int b)
        {
            if (a == b)
            {
                return 0;
            }

            var optionA = $"{a}{b}";
            var optionB = $"{b}{a}";

            for (int i = 0; i < optionA.Length; i++)
            {
                var comparision = (optionB[i] - '0').CompareTo(optionA[i] - '0');

                if (comparision != 0)
                {
                    return comparision;
                }
            }

            return 0;
        }
    }
}
