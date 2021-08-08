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

        public IList<string> RemoveComments2(string[] source)
        {
            var result = new List<string>();
            bool isComment = false;
            var sb = new StringBuilder();

            foreach (var line in source)
            {
                if (!isComment)
                {
                    sb = new StringBuilder();
                }

                int i = 0;

                while (i < line.Length)
                {
                    if (!isComment && !(line[i] == '/' && i + 1 < line.Length && (line[i + 1] == '/' || line[i + 1] == '*')))
                    {
                        sb.Append(line[i]);
                        i++;
                    }
                    else if (!isComment && line[i] == '/' && i + 1 < line.Length && line[i + 1] == '/')
                    {
                        i = line.Length;
                    }
                    else if (!isComment && line[i] == '/' && i + 1 < line.Length && line[i + 1] == '*')
                    {
                        isComment = true;
                        i++;
                        i++;
                    }
                    else if (isComment && !(line[i] == '*' && i + 1 < line.Length && line[i + 1] == '/'))
                    {
                        i++;
                    }
                    else if (isComment && line[i] == '*' && i + 1 < line.Length && line[i + 1] == '/')
                    {
                        isComment = false;
                        i++;
                        i++;
                    }
                }

                if (sb.Length > 0 && !isComment)
                {
                    result.Add(sb.ToString());
                }
            }

            return result;
        }
    }
}
