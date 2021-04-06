using System.Collections.Generic;

namespace InterviewPreparation.Exercises
{
    class TotalPermutations
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            var result = new List<IList<int>>();
            var visited = new HashSet<int>();

            foreach (var num in nums)
            {
                visited.Add(num);

                Backtrack(new List<int>() { num }, nums, visited, result);

                visited.Remove(num);
            }

            return result;
        }

        private void Backtrack(List<int> actual,
                               int[] nums,
                               HashSet<int> visited,
                               IList<IList<int>> result)
        {
            if (actual.Count == nums.Length)
            {
                result.Add(new List<int>(actual));

                return;
            }

            foreach (var num in nums)
            {
                if (!visited.Contains(num))
                {
                    visited.Add(num);
                    actual.Add(num);

                    Backtrack(actual, nums, visited, result);

                    visited.Remove(num);
                    actual.Remove(num);
                }
            }
        }
    }
}
