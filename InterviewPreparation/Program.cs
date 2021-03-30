using InterviewPreparation.Exercises;

namespace InterviewPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { 3, 2, 1, 5, 6, 4 };


            var testing = new TopFrequentK().FindKthLargest(nums, 2);
        }
    }
}
