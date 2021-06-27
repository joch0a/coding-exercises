using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class CombinationSumIII
    {
        public int[] candidates;

        public IList<IList<int>> combinations;

        public IList<IList<int>> CombinationSum3(int k, int target)
        {
            candidates = new int[9];

            for (int i = 0; i < candidates.Length; i++)
            {
                candidates[i] = i + 1;
            }

            combinations = new List<IList<int>>();

            Backtrack(0, target, new List<int>(), k);

            return combinations;
        }

        public void Backtrack(int currentIndex,
                              int target,
                              List<int> combination,
                              int k)
        {
            if (target == 0 && combination.Count == k)
            {
                combinations.Add(combination.ToList());

                return;
            }

            if (combination.Count > k)
            {
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

                    Backtrack(i + 1, target - candidate, combination, k);

                    combination.RemoveAt(combination.Count - 1);
                }
            }
        }
    }
}
