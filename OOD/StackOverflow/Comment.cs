using System;
using System.Collections.Generic;
using System.Text;

namespace OOD.StackOverflow
{
    public class Comment
    {
        public long Id { get; set; }

        public string Content { get; set; }

        public int Upvote { get; set; }

        public int FlagCount { get; set; }

        public Member Owner { get; set; }

        public DateTime CreationTime { get; set; }

    }
}
