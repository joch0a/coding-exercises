namespace OOD.StackOverflow
{
    public class Moderator : Member
    {
        public bool CloseQuestion(Question question)
        {
            return false;
        }

        public bool OpenQuestion(Question question)
        {
            return false;
        }
    }
}
