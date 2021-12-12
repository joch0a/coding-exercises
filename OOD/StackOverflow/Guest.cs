using System.Collections.Generic;

namespace OOD.StackOverflow
{
    class Guest
    {
        public int GuestId { get; set; }

        private ISearch _search;

        public Guest()
        {

        }

        public IEnumerable<Question> GetQuestions(string query) 
        {
            return _search.Search(query);
        }
    }
}
