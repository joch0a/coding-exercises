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

        ///
        public int[][] jumps;

        public int KnightDialerSolution(int n)
        {
            jumps = new int[][]
            {
            new int[] {4,6},
            new int[] {6,8},
            new int[] {7,9},
            new int[] {4,8},
            new int[] {3,9,0},
            new int[] {},
            new int[] {1,7,0},
            new int[] {2,6},
            new int[] {1,3},
            new int[] {4,2}
            };

            var dp = new int[2, 10];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i == 0)
                    {
                        dp[1, j] = 1;

                        continue;
                    }

                    foreach (var jump in jumps[j])
                    {
                        dp[1, j] += dp[0, jump];
                        dp[1, j] = dp[1, j] % Module;
                    }
                }

                for (int j = 0; j < 10; j++)
                {
                    dp[0, j] = dp[1, j];
                    dp[1, j] = 0;
                }
            }

            var sum = 0;

            for (int i = 0; i < 10; i++)
            {
                sum += dp[0, i];
                sum = sum % Module;
            }

            return sum;
        }

        private const int MOD = (int)1e9 + 7;

        public int KnightDialer3(int n)
        {
            var dp = new int[n, 10];
            var sum = 0;

            for (int i = 0; i < 10; i++)
            {
                sum += DFS(n - 1, i, dp);
            }

            sum %= MOD;

            return sum;
        }

        private int DFS(int n, int i, int[,] dp)
        {
            if (n == 0)
            {
                return 1;
            }

            if (dp[n, i] != 0)
            {
                return dp[n, i];
            }

            var sum = 0;

            foreach (var jump in jumps[i])
            {
                sum += DFS(n - 1, jump, dp);
            }

            dp[n, i] = sum % MOD;

            return dp[n, i];
        }
    }
}
