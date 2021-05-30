using System;
using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class MergeIntervals
    {
        public int[][] Merge(int[][] intervals)
        {
            var result = new List<int[]>();

            Array.Sort(intervals, (x, y) => x[0].CompareTo(y[0]));

            int i = 0;

            while (i < intervals.Length)
            {
                var start = intervals[i][0];
                var end = intervals[i][1];
                var changed = false;

                while (i < intervals.Length && intervals[i][0] <= end)
                {
                    end = Math.Max(end, intervals[i][1]);
                    i++;
                    changed = true;
                }

                result.Add(new int[] { start, end });

                if (!changed)
                {
                    i++;
                }
            }


            return result.ToArray();
        }
    }
}
