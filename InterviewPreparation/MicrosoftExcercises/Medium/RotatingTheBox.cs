namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class RotatingTheBox
    {
        public char[][] RotateTheBox(char[][] box)
        {
            var rotated = new char[box[0].Length][];

            for (int i = 0; i < rotated.Length; i++)
            {
                rotated[i] = new char[box.Length];
            }

            int j;

            for (int i = 0; i < box.Length; i++)
            {
                var totalStones = 0;

                for (j = 0; j < box[0].Length; j++)
                {
                    var current = box[i][j];

                    if (current == '#')
                    {
                        totalStones++;
                        rotated[j][box.Length - 1 - i] = '.';
                    }
                    else if (current == '.')
                    {
                        rotated[j][box.Length - 1 - i] = '.';
                    }
                    else if (current == '*')
                    {
                        rotated[j][box.Length - 1 - i] = '*';
                        var start = j - 1;

                        while (totalStones > 0)
                        {
                            rotated[start--][box.Length - 1 - i] = '#';
                            totalStones--;
                        }
                    }
                }

                j--;

                while (totalStones > 0)
                {
                    rotated[j--][box.Length - 1 - i] = '#';
                    totalStones--;
                }
            }

            return rotated;
        }
    }
}
