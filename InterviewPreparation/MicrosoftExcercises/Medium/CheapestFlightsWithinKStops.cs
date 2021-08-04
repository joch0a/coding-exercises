using System;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    public class CheapestFlightsWithinKStops
    {
        public int FindCheapestPrice(int cities, int[][] flights, int src, int dst, int k)
        {
            if (src == dst)
            {
                return 0;
            }
            var prev = new int[cities];
            Array.Fill(prev, int.MaxValue);
            prev[src] = 0;
            for (int i = 0; i <= k; i++)
            {
                var current = prev.ToArray();
                var haveChanges = false;
                for (int j = 0; j < flights.Length; j++)
                {
                    var origin = flights[j][0];
                    var destination = flights[j][1];
                    var cost = flights[j][2];
                    if (prev[origin] != int.MaxValue && prev[origin] + cost < current[destination])
                    {
                        current[destination] = prev[origin] + cost;
                        haveChanges = true;
                    }
                }
                prev = current;
                if (!haveChanges)
                {
                    break;
                }
            }
            return prev[dst] == int.MaxValue ? -1 : prev[dst];
        }
    }
}
