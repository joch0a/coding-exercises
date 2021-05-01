using System.Collections.Generic;

namespace InterviewPreparation.CommonExercises.Hard_Array
{
    class _4SumII
    {
        public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
        {
            var dict1 = new Dictionary<int, int>();
            var dict2 = new Dictionary<int, int>();
            var result = 0;

            for (int i = 0; i < nums1.Length; i++)
            {
                for (int j = 0; j < nums2.Length; j++)
                {
                    var actualSum = nums1[i] + nums2[j];

                    if (!dict1.ContainsKey(actualSum))
                    {
                        dict1.Add(actualSum, 0);
                    }

                    dict1[actualSum]++;
                }
            }

            for (int i = 0; i < nums3.Length; i++)
            {
                for (int j = 0; j < nums4.Length; j++)
                {
                    var actualSum = nums3[i] + nums4[j];

                    if (!dict2.ContainsKey(actualSum))
                    {
                        dict2.Add(actualSum, 0);
                    }

                    dict2[actualSum]++;
                }
            }


            foreach (var sumAB in dict1.Keys)
            {
                if (dict2.ContainsKey(-sumAB))
                {
                    result += dict2[-sumAB] * dict1[sumAB];
                }
            }

            return result;
        }
    }
}
