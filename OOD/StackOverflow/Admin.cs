namespace OOD.StackOverflow
{
    public class Admin : Member
    {
        public bool BlockMember(Member member) 
        {
            return false;
        }

        public bool UnblockMember(Member member)
        {
            return false;
        }
    }
}
