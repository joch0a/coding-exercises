using System.Text;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class ReverseWords
    {
        public string Solve(string s)
        {
            var sb = new StringBuilder();
            int i = 0;

            while (i < s.Length)
            {
                while (i < s.Length && s[i] == ' ')
                {
                    i++;
                }

                var actual = new StringBuilder();

                while (i < s.Length && char.IsLetterOrDigit(s[i]))
                {
                    actual.Append(s[i]);
                    i++;
                }
                actual.Append(' ');

                sb.Insert(0, actual.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
