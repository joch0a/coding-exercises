using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Hard
{
    class FrogGame
    {
        private int lastIndex;

        public bool CanCross(int[] stones)
        {
            var stonesMap = new Dictionary<int, int>();
            lastIndex = stones[stones.Length - 1];
            for (int i = 0; i < stones.Length; i++)
            {
                stonesMap.Add(stones[i], i);
            }

            var cache = new Dictionary<string, bool>();

            return CanCross(stonesMap, 0, 0, 1, cache);
        }

        private bool CanCross(Dictionary<int, int> stones, int index, int stone, int jump, Dictionary<string, bool> cache)
        {
            if (stone == lastIndex)
            {
                return true;
            }

            var key = $"{index}#{jump}";
            var result = false;

            if (cache.ContainsKey(key))
            {
                return cache[key];
            }

            if (stones.ContainsKey(stone + jump) && stones[stone + jump] > index)
            {
                result |= CanCross(stones, stones[stone + jump], stone + jump, jump, cache);
            }

            if (index > 0 && stones.ContainsKey(stone + jump + 1) && stones[stone + jump + 1] > index)
            {
                result |= CanCross(stones, stones[stone + jump + 1], stone + jump + 1, jump + 1, cache);
            }

            if (index > 0 && stones.ContainsKey(stone + jump - 1) && stones[stone + jump - 1] > index)
            {
                result |= CanCross(stones, stones[stone + jump - 1], stone + jump - 1, jump - 1, cache);
            }

            cache.Add(key, result);

            return result;
        }
    }
}
