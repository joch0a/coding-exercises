namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class CompressString
    {
        public int Compress(char[] chars)
        {
            if (chars.Length == 1)
            {
                return 1;
            }
            var actualIndex = 0;
            int i = 0;

            while (i < chars.Length)
            {
                int counter = 0;
                var letterGroup = chars[i];

                while (i < chars.Length && chars[i] == letterGroup)
                {
                    counter++;
                    i++;
                }

                chars[actualIndex] = letterGroup;
                actualIndex++;

                if (counter > 1)
                {
                    var counterString = counter.ToString();

                    for (int j = 0; j < counterString.Length; j++)
                    {
                        chars[actualIndex] = counterString[j];
                        actualIndex++;
                    }
                }
            }

            return actualIndex;
        }
    }
}
