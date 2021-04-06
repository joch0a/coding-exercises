using System;

namespace InterviewPreparation.Exercises
{
    public class LongestMountain
    {
        public int LongestMountainCount(int[] arr)
        {
            if (arr.Length < 3 || arr == null)
            {
                return 0;
            }

            var max = 0;
            var desc = 0;
            var asc = 0;

            for (var i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] < arr[i + 1])
                {
                    if (desc > 0)
                    {
                        desc = 0;
                        asc = 0;
                    }

                    asc++;
                }
                else if ((arr[i] > arr[i + 1]) && asc > 0)
                {
                    desc++;
                    max = Math.Max(max, desc + asc + 1); //El +1 es porque falta considerar 1 elemento en la forma en que se va contando 
                    // [1 2 1] => 1 > 2 asc = 1 ; 2 < 1  desc = 1, asc + desc = 2 + 1 
                }
                else
                {
                    desc = 0;
                    asc = 0;
                }
            }

            return max;
        }
    }
}
