using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class ExclusiveTime
    {
        public int[] Solve(int n, IList<string> logs)
        {
            var times = new int[n];
            var stack = new Stack<Log>();
            var prevTime = 0;
            foreach (var log in logs)
            {
                var actual = new Log(log.Split(':'));
                if (actual.State == "start")
                {
                    if (stack.Count > 0)
                    {
                        var prev = stack.Peek();
                        times[prev.Id] += actual.Time - prevTime;
                    }
                    prevTime = actual.Time;
                    stack.Push(actual);
                }
                else
                {
                    times[actual.Id] += actual.Time - prevTime + 1;
                    prevTime = actual.Time + 1;
                    stack.Pop();
                }
            }
            return times;
        }
        public class Log
        {
            public int Id { get; set; }
            public string State { get; set; }
            public int Time { get; set; }
            public Log(string[] data)
            {
                Id = int.Parse(data[0]);
                State = data[1];
                Time = int.Parse(data[2]);
            }
        }
    }
}
