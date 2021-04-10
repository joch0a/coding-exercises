using System.Text;

namespace InterviewPreparation.CommonExercises.Easy_String
{
    //https://leetcode.com/problems/longest-common-prefix
    class LongestPrefix
    {
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0)
            {
                return "";
            }

            var prefix = new StringBuilder();

            int i = 0;
            int j = 0;
            char actualChar = ' ';

            while (true)
            {
                if (j >= strs[i].Length)
                {
                    return prefix.ToString();
                }

                if (i == 0)
                {
                    actualChar = strs[i][j];
                }
                else if (actualChar != strs[i][j])
                {
                    return prefix.ToString();
                }

                i = (i + 1) % strs.Length;

                if (i == 0)
                {
                    prefix.Append(actualChar);
                    j++;
                }
            }
        }
    }
}
