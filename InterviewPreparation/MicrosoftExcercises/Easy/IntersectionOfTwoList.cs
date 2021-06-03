using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class IntersectionOfTwoList
    {
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            if (nums1.Length > nums2.Length)
            {
                var aux = nums1;
                nums1 = nums2;
                nums2 = aux;
            }

            var hsNums1 = nums1.ToHashSet();
            var solution = new HashSet<int>();

            foreach (var num in nums2)
            {
                if (hsNums1.Contains(num))
                {
                    solution.Add(num);
                }
            }

            return solution.ToArray();
        }
    }
}
