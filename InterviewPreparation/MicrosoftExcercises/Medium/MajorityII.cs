using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class MajorityII
    {
        public int[] MajorityElement(int[] nums)
        {
            var result = new List<int>();

            if (nums == null || nums.Length < 2)
            {
                return nums;
            }

            int? candidate1 = null;
            int? candidate2 = null;

            int count1 = 0;
            int count2 = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                var actual = nums[i];

                if (candidate1 != null && candidate1 == actual)
                {
                    count1++;
                }
                else if (candidate2 != null && candidate2 == actual)
                {
                    count2++;
                }
                else if (count1 == 0)
                {
                    candidate1 = actual;
                    count1++;
                }
                else if (count2 == 0)
                {
                    candidate2 = actual;
                    count2++;
                }
                else
                {
                    count1--;
                    count2--;
                }
            }

            count1 = (nums.Length) / 3;
            count2 = (nums.Length) / 3;

            foreach (var num in nums)
            {
                if (num == candidate1)
                {
                    count1--;
                }

                if (num == candidate2)
                {
                    count2--;
                }
            }

            if (count1 < 0)
            {
                result.Add(candidate1.Value);
            }

            if (count2 < 0)
            {
                result.Add(candidate2.Value);
            }

            return result.ToArray();
        }
    }
}
