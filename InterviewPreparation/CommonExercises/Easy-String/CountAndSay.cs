using System.Text;

namespace InterviewPreparation.CommonExercises.Easy_String
{
    //https://leetcode.com/explore/interview/card/top-interview-questions-easy/127/strings/886/
    class CountAndSayEx
    {
        public string CountAndSay(int n)
        {
            if (n == 1)
            {
                return "1";
            }
            else
            {
                var lastCount = CountAndSay(n - 1);
                var actualCount = new StringBuilder();
                var lastChar = ' ';
                var equals = 0;

                int i = 0;
                int j = lastCount.Length;

                while (i < j)
                {
                    if (lastChar == ' ' ||
                       lastCount[i] == lastCount[i - 1])
                    {
                        equals++;
                    }
                    else
                    {
                        actualCount.Append($"{equals}{lastChar}");
                        equals = 1;
                    }

                    lastChar = lastCount[i];
                    i++;
                }

                if (equals != 0)
                {
                    actualCount.Append($"{equals}{lastChar}");
                }

                return actualCount.ToString();
            }
        }
    }
}
