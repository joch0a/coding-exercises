using InterviewPreparation.Exercises;

namespace InterviewPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            //Testing goes here

            var b3 = new ListNode(23);
            var b2 = new ListNode(22, b3);
            var b1 = new ListNode(21, b2);
            
            var a6 = new ListNode(17);
            var a5 = new ListNode(16, a6);
            var a4 = new ListNode(15, a5);
            var a3 = new ListNode(14, a4);
            var a2 = new ListNode(12, a3);
            var a1 = new ListNode(11, a2);

            var testing = new Intersection2Lists().GetIntersectionNodeOptimized(a1, b1);

        }
    }
}
