using System;
using System.Collections.Generic;

namespace InterviewPreparation.CommonExercises.Easy_Array
{
    class IntersectionTwoArrays
    {
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            var bucketOne = new int[1000];
            var bucketTwo = new int[1000];
            var intersection = new List<int>();

            for (int i = 0; i < nums1.Length; i++)
            {
                bucketOne[nums1[i]]++;
            }

            for (int i = 0; i < nums2.Length; i++)
            {
                bucketTwo[nums2[i]]++;
            }

            for (int i = 0; i < bucketOne.Length; i++)
            {
                for (int matches = 0; matches < Math.Min(bucketOne[i], bucketTwo[i]); matches++)
                {
                    intersection.Add(i);
                }
            }

            return intersection.ToArray();
        }

        public int[] IntersectFollowUp(int[] nums1, int[] nums2)
        {
            var intersection = new List<int>();
            
            Array.Sort(nums1);
            Array.Sort(nums2);
            
            int i = 0;
            int j = 0;

            while (i < nums1.Length && j < nums2.Length) 
            {
                if (nums1[i] < nums2[j])
                {
                    i++;
                }
                else if (nums1[i] > nums2[j])
                {
                    j++;
                }
                else 
                {
                    intersection.Add(nums1[i]);
                    i++;
                    j++;
                }
            }

            return intersection.ToArray();
        }
    }
}
