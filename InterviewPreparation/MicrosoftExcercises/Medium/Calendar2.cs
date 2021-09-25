using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    public class MyCalendarTwo
    {

        public SortedDictionary<int, int> treeMap { get; set; }

        public MyCalendarTwo()
        {
            treeMap = new SortedDictionary<int, int>();
        }

        public bool Book(int start, int end)
        {
            if (!treeMap.ContainsKey(start))
            {
                treeMap.Add(start, 0);
            }

            if (!treeMap.ContainsKey(end))
            {
                treeMap.Add(end, 0);
            }

            treeMap[start]++;
            treeMap[end]--;

            var active = 0;

            foreach (var delta in treeMap)
            {
                active += delta.Value;

                if (active >= 3)
                {
                    treeMap[start]--;
                    treeMap[end]++;

                    if (treeMap[start] == 0)
                    {
                        treeMap.Remove(start);
                    }

                    if (treeMap[end] == 0)
                    {
                        treeMap.Remove(end);
                    }

                    return false;
                }

                if (delta.Key > end)
                {
                    break;
                }
            }

            return true;
        }
    }
}
