using System.Collections.Generic;
using System.Linq;

namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class PascalTriangle
    {
        public IList<IList<int>> Generate(int numRows)
        {
            var result = new List<IList<int>>();
            var level = 1;
            List<int> lastLevel = null;

            for (int i = 0; i < numRows; i++)
            {
                var actualLevel = new List<int>();
                for (int j = 0; j < level; j++)
                {
                    if (j == 0 || j == level - 1)
                    {
                        actualLevel.Add(1);
                    }
                    else
                    {
                        actualLevel.Add(lastLevel.ElementAt(j - 1) + lastLevel.ElementAt(j));
                    }
                }

                result.Add(actualLevel);
                lastLevel = actualLevel;
                level++;
            }
            return result;
        }
    }
}
