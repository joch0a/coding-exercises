using InterviewPreparation.Exercises;

namespace InterviewPreparation.CommonExercises.Easy_List
{
    class DeleteNode
    {
        public void Delete(ListNode node)
        {

            var aux = node;

            while (aux.next.next != null)
            {
                aux.val = aux.next.val;
                aux = aux.next;
            }

            aux.val = aux.next.val;
            aux.next = null;
        }
    }
}
