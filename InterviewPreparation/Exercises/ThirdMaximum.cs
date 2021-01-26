namespace InterviewPreparation.Exercises
{
    class ThirdMaximum
    {
        // https://leetcode.com/problems/third-maximum-number/

        public static int ThirdMax(int[] nums)
        {
            var max = long.MinValue;
            var maxSecond = long.MinValue;
            var maxThird = long.MinValue;
            long count = 0;

            foreach (var num in nums)
            {
                Process(num, ref max, ref maxSecond, ref maxThird, ref count);
            }

            return count >= 3 ? (int)maxThird : (int)max;
        }

        public static void Process(int value, ref long max1, ref long max2, ref long max3, ref long count)
        {
            if (value == long.MinValue || (value != max1 && value != max3 && value != max2))
            {
                count++;
                long aux;

                if (value >= max3)
                {
                    max3 = value;
                }

                if (max3 >= max2)
                {
                    aux = max2;
                    max2 = max3;
                    max3 = aux;
                }

                if (max2 > max1)
                {
                    aux = max2;
                    max2 = max1;
                    max1 = aux;
                }
            }
        }
    }
}
