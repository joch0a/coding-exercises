namespace InterviewPreparation.CommonExercises.Easy_SearchAndSorting
{
    class FirstBadVersion
    {
        public int Solve(int n)
        {
            int low = 1;
            int high = n;

            while (low <= high)
            {
                var mid = low + (high - low) / 2;

                if (IsBadVersion(mid) && !IsBadVersion(mid - 1))
                {
                    return mid;
                }
                else if (IsBadVersion(mid))
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return 1;
        }

        private bool IsBadVersion(int mid) // this is implemented on leetcode, for testing can be easily modified
        {
            throw new System.NotImplementedException();
        }
    }
}
