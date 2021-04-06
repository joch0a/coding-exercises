namespace InterviewPreparation.TrainExercises.Easy
{
    public class BuyAndSellStocks
    {
        public int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length == 1)
            {
                return 0;
            }

            int buy = prices[0];
            int sell = prices[0];
            var profit = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] < sell) //time to sell
                {
                    profit += sell - buy;
                    buy = prices[i];
                }

                sell = prices[i];
            }

            if (buy < sell)
            {
                profit += sell - buy;
            }

            return profit;
        }
    }
}
