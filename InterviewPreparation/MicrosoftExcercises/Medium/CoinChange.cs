using System;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class CoinChange
    {
        public int Solve(int[] coins, int amount)
        {
            var dp = new int[amount + 1];

            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = amount + 1;
            }

            dp[0] = 0;

            foreach (var coin in coins)
            {
                for (int i = coin; i < dp.Length; i++)
                {
                    dp[i] = Math.Min(dp[i - coin] + 1, dp[i]);
                }
            }

            return dp[amount] == amount + 1 ? -1 : dp[dp.Length - 1];
        }
    }
}
