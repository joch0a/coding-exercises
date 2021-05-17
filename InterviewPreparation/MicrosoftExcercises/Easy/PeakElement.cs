namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class PeakElement
    {
        public int PeakIndexInMountainArray(int[] arr)
        {
            var low = 0;
            var high = arr.Length - 1;
            while (low < high)
            {
                var mid = low + (high - low) / 2;

                if (mid == 0 || mid == arr.Length - 1 || (arr[mid] > arr[mid - 1] && arr[mid] > arr[mid + 1]))
                {
                    return mid;
                }
                else if (arr[mid] > arr[mid + 1] && arr[mid] < arr[mid - 1])
                {
                    high = mid;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return -1;
        }
    }
}
