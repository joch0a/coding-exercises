using System;
using System.Text;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class MultiplyStrings
    {
        public string Multiply(string n1, string n2)
        {
            if (n1 == "0" || n2 == "0")
            {
                return "0";
            }

            var result = new int[n1.Length + n2.Length];

            for (int i = n1.Length - 1; i >= 0; i--)
            {
                for (int j = n2.Length - 1; j >= 0; j--)
                {
                    result[i + j + 1] += int.Parse(n1[i].ToString()) * int.Parse(n2[j].ToString());
                }
            }

            for (int i = result.Length - 1; i > 0; i--)
            {
                result[i - 1] += result[i] / 10;
                result[i] = result[i] % 10;
            }

            var sb = new StringBuilder();

            int index = 0;

            while (result[index] == 0)
            {
                index++;
            }

            for (int i = index; i < result.Length; i++)
            {
                sb.Append(result[i]);
            }

            return sb.ToString();
        }

        public string Multiply2(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0")
            {
                return "0";
            }

            var tmp = new int[num1.Length + num2.Length];

            for (int i = 0; i < num1.Length; i++)
            {
                var n1 = (int)(num1[i] - '0');

                for (int j = 0; j < num2.Length; j++)
                {
                    var n2 = (int)(num2[j] - '0');

                    tmp[i + j + 1] += n1 * n2;
                }
            }

            for (int i = tmp.Length - 1; i > 0; i--)
            {
                var sum = tmp[i];

                tmp[i] = sum % 10;
                tmp[i - 1] += sum / 10;
            }

            var index = 0;

            while (index < tmp.Length && tmp[index] == 0)
            {
                index++;
            }

            var size = Math.Max(1, tmp.Length - index);
            var charArray = new char[size];

            for (int i = index; i < tmp.Length; i++)
            {
                charArray[i - index] = (char)(tmp[i] + '0');
            }

            return new string(charArray);
        }
    }
}
