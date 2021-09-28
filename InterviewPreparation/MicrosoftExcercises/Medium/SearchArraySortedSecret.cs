namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class SearchArraySortedSecret
    {
        public int Search(ArrayReader reader, int target)
        {
            var low = 0;
            var high = GetBound(reader);

            while (low <= high)
            {
                var mid = low + (high - low) / 2;
                var midElement = reader.Get(mid);

                if (midElement == target)
                {
                    return mid;
                }
                else if (midElement > target)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return -1;
        }

        private int GetBound(ArrayReader reader)
        {
            var low = 0;
            var high = 10000;

            while (low <= high)
            {
                var mid = low + (high - low) / 2;
                var midElement = reader.Get(mid);

                if (midElement != int.MaxValue && reader.Get(mid + 1) == int.MaxValue)
                {
                    return mid;
                }
                else if (midElement == int.MaxValue)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return -1;
        }

        public class ArrayReader
        {
            public int Get(int i) => 1;
        }
    }
}
