using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class CombinationsII
    {
        public IList<IList<int>> combinations;


        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            combinations = new List<IList<int>>();

            Array.Sort(candidates);

            Backtrack(candidates, 0, 0, target, new List<int>());

            return combinations;
        }

        public void Backtrack(int[] candidates,
                              int currentCandidate,
                              int currentIndex,
                              int target,
                              List<int> combination)
        {
            if (target == 0 && combination.Count > 0)
            {
                combinations.Add(combination.ToList());

                return;
            }

            for (int i = currentIndex; i < candidates.Length; i++)
            {
                if (i > currentIndex && candidates[i] == candidates[i - 1])
                {
                    continue;
                };

                var candidate = candidates[i];

                if (target - candidate >= 0)
                {
                    combination.Add(candidate);

                    Backtrack(candidates, candidate, i + 1, target - candidate, combination);

                    combination.RemoveAt(combination.Count - 1);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
