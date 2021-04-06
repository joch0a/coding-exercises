namespace InterviewPreparation.Exercises
{
    public class Monotonic
    {
        public bool isMonotonic(int[] A)
        {
            bool increasing = true;
            bool decreasing = true;

            for (int i = 0; i < A.Length - 1; ++i)
            {
                if (A[i] > A[i + 1])
                    increasing = false;
                if (A[i] < A[i + 1])
                    decreasing = false;
            }

            return increasing || decreasing;
        }
    }
}
