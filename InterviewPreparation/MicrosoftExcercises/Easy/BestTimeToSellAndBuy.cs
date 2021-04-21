using System;

namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class BestTimeToSellAndBuy
    {
        public int MaxProfit(int[] prices)
        {
            var profits = new int[prices.Length];
            var max = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                profits[i] = Math.Max(profits[i - 1] + (prices[i] - prices[i - 1]), 0);
                max = Math.Max(profits[i], max);
            }
            return max;
        }
    }
}
