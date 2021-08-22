using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Premium
{
    class DesignHitCounter
    {
        public class HitCounter
        {

            private LinkedList<(int timestamp, int count)> hits;
            private int total;
            /** Initialize your data structure here. */
            public HitCounter()
            {
                hits = new LinkedList<(int timestamp, int count)>();
                total = 0;
            }

            /** Record a hit.
                @param timestamp - The current timestamp (in seconds granularity). */
            public void Hit(int timestamp)
            {
                if (hits.Count > 0 && hits.Last.Value.timestamp == timestamp)
                {
                    var node = hits.Last.Value;
                    node.count++;

                    hits.RemoveLast();
                    hits.AddLast(node);
                }
                else
                {
                    hits.AddLast((timestamp, 1));
                }

                total++;
            }

            /** Return the number of hits in the past 5 minutes.
                @param timestamp - The current timestamp (in seconds granularity). */
            public int GetHits(int timestamp)
            {
                while (hits.Count > 0 && hits.First.Value.timestamp <= timestamp - 300)
                {
                    total -= hits.First.Value.count;
                    hits.RemoveFirst();
                }

                return total;
            }
        }

    }
}
