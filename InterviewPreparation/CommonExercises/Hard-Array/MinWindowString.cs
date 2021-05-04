using System.Collections.Generic;
using System.Linq;

namespace InterviewPreparation.CommonExercises.Hard_Array
{
    class MinWindowString
    {
        public string MinWindow(string s, string t)
        {
            var target = t.ToHashSet();
            var minWindow = int.MaxValue;
            var minLeft = -1;
            var minRight = -1;
            var frequencies = new Dictionary<char, int>();
            var positions = new Dictionary<char, HashSet<int>>();

            foreach (var c in t)
            {
                if (!frequencies.ContainsKey(c))
                {
                    frequencies.Add(c, 0);
                }

                frequencies[c]++;
            }

            var left = 0;
            var right = 0;

            while (right < s.Length && left < s.Length)
            {
                while (left < s.Length && IsValid(s, t, frequencies, positions))
                {
                    if (right - left + 1 < minWindow)
                    {
                        minWindow = right - left + 1;
                        minLeft = left;
                        minRight = right;
                    }

                    positions[s[left]].Remove(left);

                    left++;
                }

                if (target.Contains(s[right]))
                {
                    if (!positions.ContainsKey(s[right]))
                    {
                        positions.Add(s[right], new HashSet<int>());
                    }

                    positions[s[right]].Add(right);
                }

                right++;
            }

            while (left < s.Length && IsValid(s, t, frequencies, positions))
            {
                if (right - left + 1 < minWindow)
                {
                    minWindow = right - left + 1;
                    minLeft = left;
                    minRight = right;
                }

                positions[s[left]].Remove(left);

                left++;
            }

            return s.Substring(minLeft, minRight - minLeft);
        }

        private bool IsValid(string s, string t, Dictionary<char, int> freq, Dictionary<char, HashSet<int>> positions)
        {
            foreach (var tuple in freq)
            {
                if (positions.ContainsKey(tuple.Key))
                {
                    if (tuple.Value > positions[tuple.Key].Count)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
