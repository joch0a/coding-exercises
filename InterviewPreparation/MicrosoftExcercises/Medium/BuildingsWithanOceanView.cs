using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class BuildingsWithanOceanView
    {
        public int[] FindBuildings(int[] arr)
        {
            var maxRightSoFar = -1;
            var stack = new Stack<int>();

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (maxRightSoFar >= arr[i])
                {
                    continue;
                }

                maxRightSoFar = arr[i];

                stack.Push(i);
            }

            var result = new int[stack.Count];
            var index = 0;

            while (stack.Count > 0)
            {
                result[index++] = stack.Pop();
            }

            return result;
        }
    }
}
