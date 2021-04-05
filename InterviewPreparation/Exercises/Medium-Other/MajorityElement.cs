using System.Collections.Generic;

namespace InterviewPreparation.Exercises.Medium_Other
{
    public class MajorityElement
    {
        //o(n) time, o(n) space
        public int MajorityElement_HashMap(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums[0];
            }

            var majoritySize = nums.Length / 2;

            var dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var actual = nums[i];

                if (dict.ContainsKey(actual))
                {
                    if (dict[actual] == majoritySize)
                    {
                        return actual;
                    }

                    dict[actual] += 1;
                }
                else
                {
                    dict.Add(actual, 1);
                }
            }

            return -1;
        }

        //o(n) time, o(1) space
        public int MajorityElement_BoyerMoore(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums[0];
            }

            int candidate = nums[0];
            int count = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == candidate)
                {
                    count++;
                }
                else
                {
                    count--;

                    if (count <= 0)
                    {
                        count = 1;
                        candidate = nums[i];
                    }
                }
            }

            return candidate;
        }
    }
}
