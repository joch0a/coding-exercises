using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    public class ExclusiveTimes
    {
        public int[] ExclusiveTime(int n, IList<string> logs)
        {
            var exclusiveTimes = new int[n];
            var stack = new Stack<Interval>();
            var lastTime = 0;

            foreach (var log in logs)
            {
                var interval = new Interval(log);

                if (interval.IsStart)
                {
                    if (stack.Count > 0)
                    {
                        exclusiveTimes[stack.Peek().FunctionId] += interval.Timestamp - lastTime;
                    }

                    lastTime = interval.Timestamp;
                    stack.Push(interval);
                }
                else
                {
                    var prev = stack.Pop();
                    exclusiveTimes[prev.FunctionId] += interval.Timestamp - lastTime + 1;

                    lastTime = interval.Timestamp + 1;
                }
            }

            return exclusiveTimes;
        }
    }

    public class Interval
    {
        public int FunctionId { get; set; }

        public bool IsStart { get; set; }

        public int Timestamp { get; set; }

        public Interval(string log)
        {
            string[] decoded = log.Split(":");

            FunctionId = int.Parse(decoded[0]);
            IsStart = decoded[1] == "start";
            Timestamp = int.Parse(decoded[2]);
        }
    }
}
