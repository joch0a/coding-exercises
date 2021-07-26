using System.Text;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class CountAndSay
    {
        public string Solve(int n)
        {
            var actual = "1";
            for (int i = 1; i < n; i++)
            {
                var next = new StringBuilder();
                int j = 0;
                while (j < actual.Length)
                {
                    var count = 1;
                    var currentNumber = actual[j];
                    while (j + 1 < actual.Length && actual[j] == actual[j + 1])
                    {
                        count++;
                        j++;
                    }
                    next.Append($"{count}{currentNumber}");
                    j++;
                }
                actual = next.ToString();
            }
            return actual;
        }
    }
}
