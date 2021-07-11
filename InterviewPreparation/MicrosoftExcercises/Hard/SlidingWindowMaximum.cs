using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Hard
{
    class SlidingWindowMaximum
    {
        public int[] Solve(int[] nums, int k)
        {
            if (k == 1)
            {
                return nums;
            }

            var deque = new LinkedList<int>();
            var result = new int[nums.Length - k + 1 < 0 ? 1 : nums.Length - k + 1];

            for (int i = 0; i < nums.Length; i++)
            {
                while (deque.Count > 0 && deque.First.Value < i - k + 1)
                {
                    deque.RemoveFirst();
                }

                while (deque.Count > 0 && nums[i] > nums[deque.Last.Value])
                {
                    deque.RemoveLast();
                }

                deque.AddLast(i);

                if (i >= k - 1)
                {
                    result[i - k + 1] = nums[deque.First.Value];
                }
            }

            return result;
        }
    }
}
}
