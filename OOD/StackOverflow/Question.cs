using System.Collections.Generic;

namespace OOD.StackOverflow
{
    public class Question
    {
        private string title;
        private string description;
        private int UpvoteCount;
        private int FlagCount;
        private int ViewCount;
        private Member Owner;
        private IEnumerable<Answer> Answers;
        private QuestionClosingRemark questionClosingRemark;
        private QuestionStatus questionStatus;

        private Bounty bounty;
        private IEnumerable<Comment> Comments { get; set; }


        public Question()
        {

        }

        public bool Close()
        {
            if (questionStatus != QuestionStatus.CLOSED)
            {
                return false;
            }

            questionStatus = QuestionStatus.CLOSED;

            return true;
        }

        public bool UnClose()
        {
            return false;
        }

        public void AddComment(Comment comment) 
        {
        }

        public bool AddBounty(Bounty bounty) 
        {
            return false;
        }
    }
}
