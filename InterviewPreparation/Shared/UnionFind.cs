namespace InterviewPreparation.Shared
{
    public class UnionFind
    {
        private int[] id;
        private int[] weights;

        public UnionFind(int n)
        {
            id = new int[n];
            weights = new int[n];

            for (int i = 0; i < n; i++)
            {
                id[i] = i;
            }
        }

        public void Union(int p, int q)
        {
            int i = Find(p);
            int j = Find(q);

            if (weights[i] < weights[j])
            {
                id[i] = j;
                weights[j] += weights[i];
            }
            else
            {
                id[j] = i;
                weights[i] += weights[j];
            }

        }

        public bool Connected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        public int Find(int i) //path compression
        {
            while (i != id[i])
            {
                //id[i] = id[id[i]]; one pass compression
                i = id[i];
            }
            while (i != id[i]) // 2 pass compression ( more efficient)
            {
                id[i] = i;
            }
            return i;
        }

        public int ConnectedComponents()
        {
            int count = 0;
            for (int i = 0; i < id.Length; i++)
            {
                if (id[i] == i)
                    count++;
            }
            return count;
        }
    }
}
