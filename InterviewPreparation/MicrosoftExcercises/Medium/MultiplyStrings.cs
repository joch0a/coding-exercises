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
    }
}
