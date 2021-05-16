namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class LongestPrefix
    {
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return "";
            }

            for (int j = 0; j < strs[0].Length; j++)
            {
                var charAt = strs[0][j];

                for (int i = 1; i < strs.Length; i++)
                {
                    if (j == strs[i].Length || charAt != strs[i][j])
                    {
                        return strs[0].Substring(0, j);
                    }
                }
            }

            return strs[0];
        }
    }
}
