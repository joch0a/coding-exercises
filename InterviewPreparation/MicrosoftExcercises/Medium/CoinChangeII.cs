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
    }
}
