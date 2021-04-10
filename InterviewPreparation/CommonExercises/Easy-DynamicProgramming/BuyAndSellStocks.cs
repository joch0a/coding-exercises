using System;

namespace InterviewPreparation.CommonExercises.Easy_DynamicProgramming
{
    class BuyAndSellStocks
    {
        public int MaxProfit(int[] prices)
        {
            var profits = new int[prices.Length + 1];
            var max = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                profits[i] = Math.Max(0, profits[i - 1] + (prices[i] - prices[i - 1]));
                max = Math.Max(profits[i], max);
            }

            return max;
        }
    }
}
