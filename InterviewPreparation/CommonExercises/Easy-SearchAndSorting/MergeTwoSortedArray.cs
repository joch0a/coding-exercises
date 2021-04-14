using System;

namespace InterviewPreparation.CommonExercises.Easy_SearchAndSorting
{
    class MergeTwoSortedArray
    {
        //First approach space & time O(N) 
        public void Solve1(int[] nums1, int m, int[] nums2, int n)
        {
            var solution = new int[nums1.Length];
            var i = 0;
            var p1 = 0;
            var p2 = 0;

            while (p1 < m && p2 < n)
            {
                if (nums1[p1] <= nums2[p2])
                {
                    solution[i] = nums1[p1];
                    p1++;
                }
                else
                {
                    solution[i] = nums2[p2];
                    p2++;
                }
                i++;
            }

            while (p1 < m)
            {
                solution[i] = nums1[p1];
                p1++;
                i++;
            }

            while (p2 < n)
            {
                solution[i] = nums2[p2];
                p2++;
                i++;
            }

            Array.Copy(solution, nums1, n + m);
        }


        //Space o(1) time o(n)
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            var p1 = m - 1;
            var p2 = n - 1;

            for (int i = nums1.Length - 1; i >= 0; i--)
            {
                // can be improved if p2 < 0 -> break
                if (p1 < 0)
                {
                    nums1[i] = nums2[p2];
                    p2--;
                }
                else if (p2 < 0 || nums1[p1] >= nums2[p2])
                {
                    nums1[i] = nums1[p1];
                    p1--;
                }
                else
                {
                    nums1[i] = nums2[p2];
                    p2--;
                }
            }
        }
    }
}
