using System;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class CoinChangeII
    {
        public int Change(int amount, int[] coins)
        {
            int[] dp = new int[amount + 1];

            dp[0] = 1;

            foreach (var coin in coins)
            {
                for (int i = coin; i < dp.Length; i++)
                {
                    dp[i] += dp[i - coin];
                }
            }

            return dp[amount];
        }

        public int ChangeReview(int amount, int[] coins)
        {
            var M = coins.Length + 1;
            var N = amount + 1;

            var dp = new int[M, N];

            for (int i = 0; i < M; i++)
            {
                dp[i, 0] = 1;
            }

            for (int i = 1; i < M; i++)
            {
                var coin = coins[i - 1];

                for (int j = 0; j < coin && j < N; j++)
                {
                    dp[i, j] = dp[i - 1, j];
                }

                for (int j = coin; j < N; j++)
                {
                    dp[i, j] = dp[i - 1, j] + dp[i, j - coin];
                }
            }

            return dp[M - 1, N - 1];
        }

        public int Change2(int amount, int[] coins)
        {
            var cache = new int?[coins.Length + 1, amount + 1];

            Array.Sort(coins);

            return DFS(coins, amount, 0, cache);
        }

        private int DFS(int[] coins, int amount, int index, int?[,] cache)
        {
            if (amount == 0)
            {
                return 1;
            }

            if (index == coins.Length)
            {
                return 0;
            }

            if (cache[index, amount] != null)
            {
                return cache[index, amount].Value;
            }

            var total = 0;

            for (int i = index; i < coins.Length; i++)
            {
                if (amount < coins[i])
                {
                    break;
                }

                var times = 1;

                while (times * coins[i] <= amount)
                {
                    total += DFS(coins, amount - times * coins[i], i + 1, cache);
                    times++;
                }
            }

            cache[index, amount] = total;

            return total;
        }
    }
}
