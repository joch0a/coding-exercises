using System.Collections.Generic;
using System.Linq;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class Permutations
    {
        public HashSet<int> visited { get; set; } = new HashSet<int>();

        public IList<IList<int>> Permute(int[] nums)
        {
            var result = new List<IList<int>>();

            foreach (var num in nums)
            {
                visited.Add(num);

                Backtrack(nums, result);

                visited.Remove(num);
            }

            return result;
        }

        public void Backtrack(int[] nums, IList<IList<int>> result)
        {
            if (visited.Count == nums.Length)
            {
                result.Add(visited.ToList());
                return;
            }

            foreach (var num in nums)
            {
                if (!visited.Contains(num))
                {
                    visited.Add(num);

                    Backtrack(nums, result);

                    visited.Remove(num);
                }
            }
        }
    }
}
