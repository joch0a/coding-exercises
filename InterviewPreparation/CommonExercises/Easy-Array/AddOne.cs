using System.Linq;

namespace InterviewPreparation.CommonExercises.Easy_Array
{
    class AddOne
    {
        // https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/559/

        public int[] PlusOne(int[] digits)
        {
            int carry = 1;

            for (int i = digits.Length - 1; i >= 0 && carry != 0; i--)
            {
                var actual = digits[i] + carry;
                carry = actual / 10;

                digits[i] = actual % 10;
            }

            if (carry != 0)
            {
                digits = new int[] { 1 }.Concat(digits).ToArray();
            }

            return digits;
        }
    }
}
