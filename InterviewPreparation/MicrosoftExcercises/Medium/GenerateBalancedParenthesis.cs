using System.Collections.Generic;
using System.Text;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class GenerateBalancedParenthesis
    {
        public IList<string> result;
        public IList<string> GenerateParenthesis(int n)
        {
            result = new List<string>();
            Backtrack(n, 0, new StringBuilder(), 0, 0);
            return result;
        }
        public void Backtrack(int n, int total, StringBuilder actual, int open, int closed)
        {
            if (total == n * 2)
            {
                result.Add(actual.ToString());
                return;
            }
            if (open < n)
            {
                actual.Append('(');
                Backtrack(n, total + 1, actual, open + 1, closed);
                actual.Remove(actual.Length - 1, 1);
            }
            if (closed < open)
            {
                actual.Append(')');
                Backtrack(n, total + 1, actual, open, closed + 1);
                actual.Remove(actual.Length - 1, 1);
            }
        }
    }
}
