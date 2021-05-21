namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class BuyStock
    {
        public int MaxProfit(int[] prices)
        {
            var profit = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                var diff = prices[i] - prices[i - 1];
                if (diff > 0)
                {
                    profit += diff;
                }
            }

            return profit;
        }
    }
}
