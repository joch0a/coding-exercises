using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class FindSmallestKPairs
    {
        public IList<IList<int>> KSmallestPairsBruteForce(int[] nums1, int[] nums2, int k)
        {
            var result = new List<IList<int>>();
            var len1 = Math.Min(nums1.Length, k);
            var len2 = Math.Min(nums2.Length, k);
            for (int i = 0; i < len1; i++)
            {
                for (int j = 0; j < len2; j++)
                {
                    result.Add(new List<int>() { nums1[i], nums2[j] });
                }
            }

            return result.OrderBy(array => array.Sum()).Take(k).ToList();
        }

        public IList<IList<int>> KSmallestPairsUsingSet(int[] nums1, int[] nums2, int k)
        {
            var pairSet = new SortedSet<(int nums1Index, int nums2Index)>(new Comparer(nums1, nums2));
            var result = new List<IList<int>>();

            if (nums1.Length > 0 && nums2.Length > 0)
            {
                pairSet.Add((0, 0));
            }

            while (pairSet.Any() && k > 0)
            {
                var min = pairSet.Min;

                pairSet.Remove(min);

                result.Add(new List<int>() { nums1[min.nums1Index], nums2[min.nums2Index] });

                if (min.nums1Index < nums1.Length - 1)
                {
                    pairSet.Add((min.nums1Index + 1, min.nums2Index));
                }

                if (min.nums2Index < nums2.Length - 1)
                {
                    pairSet.Add((min.nums1Index, min.nums2Index + 1));
                }

                k--;
            }

            return result;
        }

        public class Comparer : IComparer<(int nums1Index, int nums2Index)>
        {
            int[] nums1;
            int[] nums2;

            public Comparer(int[] nums1, int[] nums2)
            {
                this.nums1 = nums1;
                this.nums2 = nums2;
            }

            public int Compare((int nums1Index, int nums2Index) A, (int nums1Index, int nums2Index) B)
            {
                var s1 = nums1[A.nums1Index] + nums2[A.nums2Index];
                var s2 = nums1[B.nums1Index] + nums2[B.nums2Index];

                var result = s1 - s2;

                if (result != 0)
                {
                    return result;
                }

                result = A.nums1Index - B.nums1Index;

                if (result != 0)
                {
                    return result;
                }

                return A.nums2Index - B.nums2Index;
            }
        }
    }
}
