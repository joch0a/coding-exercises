namespace InterviewPreparation.Exercises
{
    public class KadaneAlgorithm
    {
        // Largest Sum Contiguous Subarray
        public int KadanesAlgorithm(int[] array)
        {
            var currentMax = array[0];
            var globalMax = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                var num = array[i];
                currentMax = Math.Max(num, currentMax + num);
                globalMax = Math.Max(globalMax, currentMax);
            }

            return globalMax;
        }
    }
}
