using System.Collections.Generic;
using System.Linq;

namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class PlusOne
    {
        public int[] Solve(int[] digits)
        {
            var carry = 1;

            var list = new LinkedList<int>();

            for (int i = digits.Length - 1; i >= 0; i--)
            {
                var sum = digits[i] + carry;


                list.AddFirst(sum % 10);
                carry = sum / 10;
            }

            if (carry > 0)
            {
                list.AddFirst(carry);
            }

            return list.ToArray();
        }
    }
}
