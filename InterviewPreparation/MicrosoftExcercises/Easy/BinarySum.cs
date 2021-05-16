using System;

namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class BinarySum
    {
        public string AddBinary(string a, string b)
        {
            var result = new char[Math.Max(a.Length, b.Length) + 1];

            var carry = 0;
            var i = a.Length - 1;
            var j = b.Length - 1;
            var resultIndex = result.Length - 1;

            while (i >= 0 || j >= 0)
            {
                var aValue = i >= 0 ? int.Parse(a[i].ToString()) : 0;
                var bValue = j >= 0 ? int.Parse(b[j].ToString()) : 0;
                var sum = aValue + bValue + carry;

                result[resultIndex] = sum == 1 || sum == 3 ? '1' : '0';
                carry = sum == 2 || sum == 3 ? 1 : 0;

                i--;
                j--;
                resultIndex--;
            }

            if (carry == 1)
            {
                result[0] = '1';

                return new string(result);
            }

            return new string(result).Substring(1, result.Length - 1);
        }
    }
}
