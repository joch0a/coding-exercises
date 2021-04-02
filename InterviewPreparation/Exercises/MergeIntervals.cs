using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewPreparation.Exercises
{
    public class MergeIntervals
    {
        public int[][] Merge(int[][] intervals)
        {
            Array.Sort(intervals, (i1, i2) => i1[0].CompareTo(i2[0]));

            IList<int[]> res = new List<int[]>();
            int i = 0;
            int j = 1;

            while (i < intervals.Length)
            {
                int low = intervals[i][0];
                int high = intervals[i][1];

                while (j < intervals.Length && intervals[j][0] <= high)
                {
                    high = Math.Max(high, intervals[j][1]);
                    j++;
                }

                res.Add(new[] { low, high });

                i = j;
                j = i + 1;
            }

            return res.ToArray();
        }
    }
}
