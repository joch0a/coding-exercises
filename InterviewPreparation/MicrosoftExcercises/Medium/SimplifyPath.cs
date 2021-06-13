using System.Collections.Generic;
using System.Text;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class SimplifyPath
    {
        public string Solve(string path)
        {
            var words = new LinkedList<string>();

            int i = 0;

            while (i < path.Length)
            {
                var actualWordSb = new StringBuilder();

                if (path[i] == '/')
                {
                    i++;
                    continue;
                }

                while (i < path.Length && path[i] != '/')
                {
                    actualWordSb.Append(path[i]);
                    i++;
                }

                var actualWord = actualWordSb.ToString();

                if (actualWord == ".")
                {
                    continue;
                }
                else if (actualWord == "..")
                {
                    if (words.Count > 0)
                    {
                        words.RemoveLast();
                    }
                }
                else if (actualWord.Length > 0)
                {
                    words.AddLast(actualWord);
                }
            }

            var index = 0;
            var result = new StringBuilder();

            result.Append("/");

            foreach (var word in words)
            {
                result.Append($"{word}");

                if (index < words.Count - 1)
                {
                    result.Append("/");
                }

                index++;
            }

            return result.ToString();
        }
    }
}
