using System.Collections.Generic;

namespace OOD.StackOverflow
{
    public class Member
    {
        public Account Account { get; set; }

        public IEnumerable<Badge> Badges { get; set; }

        public Member()
        {
        }

        public bool AddQuestion(Question question) 
        {
            return false;
        }

        public bool AddTag(Tag question)
        {
            return false;
        }
    }
}
