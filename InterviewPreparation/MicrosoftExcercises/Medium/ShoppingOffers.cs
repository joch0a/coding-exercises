using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class ShoppingOffers
    {
        public Dictionary<string, int> memo;

        public int Solved(IList<int> price, IList<IList<int>> special, IList<int> needs)
        {
            memo = new Dictionary<string, int>();

            return Shopping(price.ToArray(), special.ToArray(), needs.ToArray());
        }

        private int Shopping(int[] price, IList<int>[] special, int[] needs)
        {
            var needsKey = GetNeedsKey(needs);

            if (memo.ContainsKey(needsKey))
            {
                return memo[needsKey];
            }

            var totalCost = GetCost(price, needs);

            foreach (var offer in special)
            {
                int[] clone = new int[needs.Length];

                Array.Copy(needs, clone, needs.Length);

                int i;

                for (i = 0; i < clone.Length; i++)
                {
                    var diff = clone[i] - offer.ElementAt(i);

                    if (diff < 0)
                    {
                        break;
                    }

                    clone[i] = diff;
                }

                if (i == clone.Length)
                {
                    totalCost = Math.Min(totalCost, offer.ElementAt(i) + Shopping(price, special, clone));
                }
            }

            memo.Add(needsKey, totalCost);

            return totalCost;
        }

        public int GetCost(int[] price, int[] needs)
        {
            var cost = 0;

            for (int i = 0; i < price.Length; i++)
            {
                cost += price[i] * needs[i];
            }

            return cost;
        }

        public string GetNeedsKey(int[] needs)
        {
            var sb = new StringBuilder();

            foreach (var need in needs)
            {
                sb.Append($"{need}#");
            }

            return sb.ToString();
        }
    }
}
