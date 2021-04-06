using System.Collections.Generic;
using System.Text;

namespace InterviewPreparation.Exercises
{
    class GenerateAllBalancedParenthesis
    {
        public IList<string> GenerateParenthesis(int n)
        {
            var paths = new List<string>();

            Backtrack(new StringBuilder(), 0, 0, n, paths);

            return paths;
        }

        public void Backtrack(StringBuilder path, int open, int closed, int max, IList<string> paths)
        {
            if (path.Length == max * 2)
            {
                paths.Add(path.ToString());

                return;
            }

            if (open < max)
            {
                Backtrack(path.Append('('), open + 1, closed, max, paths);
                path.Remove(path.Length - 1, 1);
            }

            if (closed < open)
            {
                Backtrack(path.Append(')'), open, closed + 1, max, paths);
                path.Remove(path.Length - 1, 1);
            }
        }
    }
}
