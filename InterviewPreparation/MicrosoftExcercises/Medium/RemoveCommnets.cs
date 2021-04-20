using System.Collections.Generic;
using System.Text;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class RemoveCommnets
    {
        public IList<string> RemoveComments(string[] source)
        {
            var result = new List<string>();
            var sb = new StringBuilder();
            var inBlock = false;

            foreach (var line in source)
            {
                sb = inBlock ? sb : new StringBuilder();

                for (int i = 0; i < line.Length; i++)
                {
                    if (!inBlock && i < line.Length - 1 && line[i] == '/' && line[i + 1] == '*')
                    {
                        inBlock = true;
                        i++;
                    }
                    else if (inBlock && i < line.Length - 1 && line[i] == '*' && line[i + 1] == '/')
                    {
                        inBlock = false;
                        i++;
                    }
                    else if (!inBlock && i < line.Length - 1 && line[i] == '/' && line[i + 1] == '/')
                    {
                        break;
                    }
                    else if (!inBlock)
                    {
                        sb.Append(line[i]);
                    }
                }

                if (!inBlock && sb.Length > 0)
                {
                    result.Add(sb.ToString());
                }
            }

            return result;
        }
    }
}
