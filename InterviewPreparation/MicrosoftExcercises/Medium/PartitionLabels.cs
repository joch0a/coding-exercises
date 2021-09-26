using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class PartitionLabels
    {
        public IList<int> Solve(string s)
        {
            var dict = new Dictionary<char, int[]>();

            for (int i = 0; i < s.Length; i++)
            {
                var current = s[i];

                if (!dict.ContainsKey(current))
                {
                    dict.Add(current, new int[] { i, i });
                }

                dict[current][1] = i;
            }

            var intervalsMerged = MergeIntervals(dict.Values.ToList());
            var result = new List<int>();

            foreach (var interval in intervalsMerged)
            {
                result.Add(interval[1] - interval[0] + 1);
            }

            return result;
        }

        private IList<int[]> MergeIntervals(IList<int[]> intervals)
        {
            var merged = new List<int[]>();

            intervals = intervals.OrderBy(interval => interval[0]).ToList();

            var i = 0;
            var j = i + 1;

            while (i < intervals.Count)
            {
                var current = intervals[i];
                var start = current[0];
                var end = current[1];

                while (j < intervals.Count && intervals[j][0] < end)
                {
                    end = Math.Max(end, intervals[j][1]);
                    j++;
                }

                merged.Add(new int[] { start, end });
                i = j;
                j = j + 1;
            }

            return merged;
        }

        // GREEDY

        public IList<int> PartitionLabelsGreedy(string s)
        {
            var max = new int[26];
            var result = new List<int>();

            for (int i = 0; i < s.Length; i++)
            {
                max[s[i] - 'a'] = i;
            }

            var j = 0;
            var initial = 0;

            for (int i = 0; i < s.Length; i++)
            {
                var current = s[i];

                j = Math.Max(j, max[current - 'a']);

                if (i == j)
                {
                    result.Add(i - initial + 1);
                    initial = i + 1;
                }
            }

            return result;
        }
    }
}
