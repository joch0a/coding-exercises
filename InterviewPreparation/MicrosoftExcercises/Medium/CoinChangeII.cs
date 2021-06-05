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
    }
}
