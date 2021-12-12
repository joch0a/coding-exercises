using System;

namespace OOD.StackOverflow
{
    public class Answer
    {
        public string AnswerText { get; set; }

        public bool Accepted { get; set; }

        public int VoteCount { get; set; }

        public int FlagCount { get; set; }

        public DateTime Creation { get; set; }

        public Member Owner { get; set; }
    }
}
