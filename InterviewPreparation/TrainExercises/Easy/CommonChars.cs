using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewPreparation.TrainExercises.Easy
{
    class CommonChars
    {
        public IList<string> Solve(string[] A)
        {
            var bucketList = new List<int[]>();

            foreach (var str in A)
            {
                bucketList.Add(GetFreq(str));
            }

            var result = new List<string>();

            for (int i = 1; i < bucketList.Count; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    bucketList.ElementAt(i)[j] = Math.Min(bucketList.ElementAt(i)[j], bucketList.ElementAt(i - 1)[j]);

                    if (i == bucketList.Count - 1)
                    {
                        while (bucketList.ElementAt(i)[j] > 0)
                        {
                            result.Add(((char)(j + 'a')).ToString());
                            bucketList.ElementAt(i)[j]--;
                        }
                    }
                }
            }

            return result;
        }

        public int[] GetFreq(string str)
        {
            var result = new int[26];

            foreach (var c in str)
            {
                result[c - 'a']++;
            }

            return result;
        }
    }
}
