using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class FizzBuzz
    {
        public IList<string> Solve(int n)
        {
            var result = new List<string>();

            for (int i = 1; i <= n; i++)
            {
                var div3 = i % 3 == 0;
                var div5 = i % 5 == 0;

                if (div3 && div5)
                {
                    result.Add("FizzBuzz");
                }
                else if (div3)
                {
                    result.Add("Fizz");
                }
                else if (div5)
                {
                    result.Add("Buzz");
                }
                else
                {
                    result.Add($"{i}");
                }
            }

            return result;
        }
    }
}
