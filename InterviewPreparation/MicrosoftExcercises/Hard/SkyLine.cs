using System;
using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Hard
{
    public class SkyLine
    {
        public IList<IList<int>> GetSkyline(int[][] buildings)
        {
            return GetSkyline(buildings, 0, buildings.Length - 1);
        }

        public IList<IList<int>> GetSkyline(IList<IList<int>> buildings, int left, int right)
        {
            var length = right - left + 1;

            if (length == 1)
            {
                var actual = buildings[left];
                var end = new int[] { actual[1], 0 };

                return new List<IList<int>> { new int[] {actual[0], actual[2] }, end };
            }
            else
            {
                var mid = left + (right - left) / 2;
                var leftSide = GetSkyline(buildings, left, mid);
                var rightSide = GetSkyline(buildings, mid + 1, right);

                return Merge(leftSide, rightSide);
            }
        }

        public IList<IList<int>> Merge(IList<IList<int>> left, IList<IList<int>> right)
        {
            var merged = new List<IList<int>>();
            var leftPointer = 0;
            var rightPointer = 0;
            var leftHeight = 0;
            var rightHeight = 0;
            var skyline = 0;

            while (leftPointer < left.Count && rightPointer < right.Count)
            {
                int currentPosition;

                if (left[leftPointer][0] < right[rightPointer][0])
                {
                    leftHeight = left[leftPointer][2];
                    currentPosition = left[leftPointer][0];
                    leftPointer++;
                }
                else if (left[leftPointer][0] > right[rightPointer][0])
                {
                    rightHeight = right[rightPointer][2];
                    currentPosition = right[rightPointer][0];
                    rightPointer++;
                }
                else
                {
                    leftHeight = left[leftPointer][2];
                    rightHeight = right[rightPointer][2];
                    currentPosition = left[leftPointer][0];
                    rightPointer++;
                    leftPointer++;
                }

                if (skyline != Math.Max(leftHeight, rightHeight))
                {
                    skyline = Math.Max(leftHeight, rightHeight);

                    merged.Add(new int[] { currentPosition, skyline });
                }
            }

            for (int i = leftPointer; i < left.Count; i++) 
            {
                merged.Add(left[i]);
            }

            for (int i = rightPointer; i < right.Count; i++)
            {
                merged.Add(right[i]);
            }

            return merged;
        }
    }
}
