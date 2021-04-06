using System;

namespace InterviewPreparation.Exercises.DynamicProgramming
{
    class CoinChangeDP
    {
        public int CoinChange(int[] coins, int amount)
        {
            var arr = new int[amount + 1];

            for (int i = 0; i < amount + 1; i++)
            {
                arr[i] = amount + 1;
            }

            arr[0] = 0;

            for (int i = 1; i < coins.Length + 1; i++)
            {
                var denomination = coins[i - 1];

                for (int j = denomination; j < amount + 1; j++)
                {
                    arr[j] = Math.Min(arr[j], arr[j - denomination] + 1);
                }
            }

            return arr[amount] == amount + 1 ? -1 : arr[amount];
        }
    }
}
