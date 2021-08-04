namespace InterviewPreparation.MicrosoftExcercises.Hard
{
    class ReversePairs
    {
        public int Solve(int[] nums)
        {
            int count = 0;

            MergeAndCount(nums, 0, nums.Length - 1, ref count);

            return count;
        }

        public int[] MergeAndCount(int[] nums, int left, int right, ref int count)
        {
            if (left == right)
            {
                return new int[] { nums[left] };
            }

            var mid = left + (right - left) / 2;

            var leftPartition = MergeAndCount(nums, left, mid, ref count);
            var rightPartition = MergeAndCount(nums, mid + 1, right, ref count);

            return Merge(leftPartition, rightPartition, ref count);
        }

        public int[] Merge(int[] left, int[] right, ref int count)
        {
            var merged = new int[left.Length + right.Length];
            var indexLeft = 0;
            var indexRight = 0;
            var indexMerge = 0;

            while (indexLeft < left.Length && indexRight < right.Length)
            {
                if (left[indexLeft] <= right[indexRight])
                {
                    merged[indexMerge] = left[indexLeft];
                    indexLeft++;
                }
                else
                {
                    merged[indexMerge] = right[indexRight];
                    indexRight++;
                }

                indexMerge++;
            }

            while (indexLeft < left.Length)
            {
                merged[indexMerge] = left[indexLeft];
                indexLeft++;
                indexMerge++;
            }

            while (indexRight < right.Length)
            {
                merged[indexMerge] = right[indexRight];
                indexRight++;
                indexMerge++;
            }

            indexLeft = 0;
            indexRight = 0;

            while (indexLeft < left.Length && indexRight < right.Length)
            {
                if ((long)(left[indexLeft]) <= (long)(((long)2) * right[indexRight]))
                {
                    indexLeft++;
                }
                else
                {
                    count += left.Length - indexLeft;
                    indexRight++;
                }
            }

            return merged;
        }
    }
}
}
