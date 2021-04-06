using System;

namespace InterviewPreparation.TrainExercises.Easy
{
    // https://leetcode.com/problems/minimum-changes-to-make-alternating-binary-string/
    class MinimunChangesAlternatingBinaryString
    {
        public int MinOperations(string s)
        {
            var swapsOne = 0;
            var swapsTwo = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (i % 2 == 0)
                {
                    if (s[i] == '1')
                    {
                        swapsOne++;
                    }
                    else
                    {
                        swapsTwo++;
                    }
                }
                else
                {
                    if (s[i] == '0')
                    {
                        swapsOne++;
                    }
                    else
                    {
                        swapsTwo++;
                    }
                }
            }

            return Math.Min(swapsOne, swapsTwo);
        }
    }
}
