using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class CombinationSum
    {
        private IList<IList<int>> combinations;

        public IList<IList<int>> Solve(int[] candidates, int target)
        {
            combinations = new List<IList<int>>();

            Array.Sort(candidates);

            Backtrack(candidates, target, new Stack<int>(), 0);

            return combinations;
        }

        private void Backtrack(int[] candidates, int target, Stack<int> currentCombination, int initialIndex)
        {
            if (target == 0)
            {
                combinations.Add(currentCombination.ToList());

                return;
            }

            if (currentCombination.Count >= 150)
            {
                return;
            }

            for (int i = initialIndex; i < candidates.Length; i++)
            {
                var candidate = candidates[i];

                if (target - candidate >= 0)
                {
                    currentCombination.Push(candidate);

                    Backtrack(candidates, target - candidate, currentCombination, i);

                    currentCombination.Pop();
                }
                else
                {
                    break;
                }
            }
        }
    }
}
