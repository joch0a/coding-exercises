using System;

namespace InterviewPreparation.MicrosoftExcercises.Hard
{
    class MedianSorted
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1.Length > nums2.Length)
            {
                var aux = nums1;
                nums1 = nums2;
                nums2 = aux;
            }
            var total = nums1.Length + nums2.Length;

            var low = 0;
            var high = nums1.Length;

            while (low <= high)
            {
                var positionX = (low + high) / 2;
                var positionY = ((total + 1) / 2) - positionX;

                var leftX = GetMax(nums1, positionX);
                var rightX = GetMin(nums1, positionX);

                var leftY = GetMax(nums2, positionY);
                var rightY = GetMin(nums2, positionY);


                if (leftX <= rightY &&
                   leftY <= rightX)
                {
                    if ((total) % 2 == 0)
                    {
                        return (Math.Max(leftX, leftY) + Math.Min(rightX, rightY)) / 2.0;
                    }
                    else
                    {
                        return Math.Max(leftX, leftY);
                    }
                }

                if (leftX > rightY)
                {
                    high = positionX - 1;
                }
                else
                {
                    low = positionX + 1;
                }
            }

            return -1;
        }


        private int GetMax(int[] nums, int position)
        {
            if (position == 0)
            {
                return int.MinValue;
            }

            return nums[position - 1];
        }

        private int GetMin(int[] nums, int position)
        {
            if (position == nums.Length)
            {
                return int.MaxValue;
            }

            return nums[position];
        }
    }
}
