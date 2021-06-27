using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class FindClosestElements
    {
        public IList<int> Solve(int[] arr, int k, int x)
        {
            // Initialize binary search bounds
            int low = 0;
            int high = arr.Length - k;

            while (low < high)
            {
                var mid = low + (high - low) / 2;

                if (x - arr[mid] > arr[mid + k] - x)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid;
                }
            }

            var result = new List<int>();

            for (int i = low; i < low + k; i++)
            {
                result.Add(arr[i]);
            }

            return result;
        }
    }
}
