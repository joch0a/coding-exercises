namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class BestTimetoBuyandSellStockII
    {
        public int MaxProfit(int[] prices)
        {
            var profit = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                {
                    profit += prices[i] - prices[i - 1];
                }
            }

            return profit;
        }
    }
}
