using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    public class CalendarI
    {
        private List<int[]> books;

        public CalendarI()
        {
            books = new List<int[]>();
        }

        public bool Book(int start, int end)
        {
            foreach (var book in books)
            {
                if (!Avaliable(book, start, end))
                {
                    return false;
                }
            }

            books.Add(new int[] { start, end });

            return true;
        }

        private bool Avaliable(int[] book, int start, int end)
        {
            return !(book[0] < end && start < book[1]);
        }
    }
}
