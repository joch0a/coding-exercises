using System;
using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class InsertInterval
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            var aux = new int[intervals.Length + 1][];
            var i = 0;
            var inserted = false;

            foreach (var actual in intervals)
            {
                if (!inserted && newInterval[0] < actual[0])
                {
                    inserted = true;
                    aux[i] = newInterval;
                    i++;
                }

                aux[i] = actual;
                i++;
            }

            if (!inserted)
            {
                aux[i] = newInterval;
            }


            var result = new List<int[]>();

            i = 0;
            int j;

            while (i < aux.Length)
            {
                var actual = aux[i];
                j = i + 1;
                var max = actual[1];
                var isNew = false;

                while (j < aux.Length && aux[j][0] >= actual[0] && aux[j][0] <= max)
                {
                    isNew = true;
                    max = Math.Max(max, aux[j][1]);
                    j++;
                }

                if (isNew)
                {
                    result.Add(new int[] { actual[0], max });
                    i = j;
                }
                else
                {
                    result.Add(actual);
                    i++;
                }
            }

            return result.ToArray();
        }
    }
}
