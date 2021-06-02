using System.Collections.Generic;
using System.Text;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class KnightDialer
    {
        // First approach
        public int TotalCount = 0;
        public int Module = 1000000007;
        public char[][] dialer;

        public int Solve(int n)
        {
            var sb = new StringBuilder();
            dialer = new char[][] { new char[] { '1', '2', '3' }, new char[] { '4', '5', '6' }, new char[] { '7', '8', '9' }, new char[] { '*', '0', '#' } };
            for (int i = 0; i < dialer.Length; i++)
            {
                for (int j = 0; j < dialer[i].Length; j++)
                {
                    if (char.IsDigit(dialer[i][j]))
                    {
                        sb.Append(dialer[i][j]);
                        Backtrack(n, sb, i, j);
                        sb.Remove(sb.Length - 1, 1);
                    }
                }
            }

            return TotalCount;
        }

        public void Backtrack(int maxLength, StringBuilder actualPhone, int i, int j)
        {
            if (actualPhone.Length == maxLength)
            {
                TotalCount = (TotalCount + 1) % Module;
                return;
            }

            var neighbours = GetValidNeighbours(i, j);

            foreach (var neighbour in neighbours)
            {
                actualPhone.Append(dialer[neighbour[0]][neighbour[1]]);
                Backtrack(maxLength, actualPhone, neighbour[0], neighbour[1]);
                actualPhone.Remove(actualPhone.Length - 1, 1);
            }
        }

        public IEnumerable<int[]> GetValidNeighbours(int i, int j)
        {
            var dI = new int[] { -2, -2, -1, -1, 1, 1, 2, 2 };
            var dJ = new int[] { -1, 1, -2, 2, -2, 2, -1, 1 };
            var result = new List<int[]>();

            for (int x = 0; x < dI.Length; x++)
            {
                var newI = i + dI[x];
                var newJ = j + dJ[x];

                if (newI >= 0 &&
                   newI < dialer.Length &&
                   newJ >= 0 &&
                   newJ < dialer[newI].Length &&
                   char.IsDigit(dialer[newI][newJ]))
                {
                    result.Add(new int[] { newI, newJ });
                }
            }

            return result;
        }
    }
}
