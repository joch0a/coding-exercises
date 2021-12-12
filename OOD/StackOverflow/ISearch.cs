using System.Collections.Generic;

namespace OOD.StackOverflow
{
    interface ISearch
    {
        IEnumerable<Question> Search(string query);
    }
}
