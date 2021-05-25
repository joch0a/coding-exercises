namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    public class MyHashMap
    {

        private int[] map;

        /** Initialize your data structure here. */
        public MyHashMap()
        {
            map = new int[1000001];
        }

        /** value will always be non-negative. */
        public void Put(int key, int value)
        {
            map[key] = value + 1;
        }

        /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
        public int Get(int key)
        {
            return map[key] - 1;
        }

        /** Removes the mapping of the specified value key if this map contains a mapping for the key */
        public void Remove(int key)
        {
            map[key] = 0;
        }
    }
}
