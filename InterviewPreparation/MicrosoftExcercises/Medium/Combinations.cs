using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class CombinationsI
    {
        public IList<IList<int>> Combinations;

        public IList<IList<int>> Combine(int n, int k)
        {
            Combinations = new List<IList<int>>();

            var candidates = new int[n];

            for (int i = 0; i < candidates.Length; i++)
            {
                candidates[i] = i + 1;
            }

            Backtrack(candidates, 0, k, new HashSet<int>());

            return Combinations;
        }

        public void Backtrack(int[] candidates, int start, int k, HashSet<int> combination)
        {
            if (k == 0)
            {
                Combinations.Add(combination.ToList());

                return;
            }

            for (int currentIndex = start; currentIndex < candidates.Length; currentIndex++)
            {
                var candidate = candidates[currentIndex];

                combination.Add(candidate);
                Backtrack(candidates, currentIndex + 1, k - 1, combination);
                combination.Remove(candidate);
            }
        }
    }
}
