namespace InterviewPreparation.MicrosoftExcercises.Hard
{
    public class MedianFinder
    {

        private ListNodeCustom _streamHead;
        private int _length;

        /** initialize your data structure here. */
        public MedianFinder()
        {
            _streamHead = new ListNodeCustom(0);
            _length = 0;
        }

        public void AddNum(int num)
        {
            var prev = _streamHead;
            var current = _streamHead.Next;

            while (current != null && current.Value < num)
            {
                prev = current;
                current = current.Next;
            }

            var newNode = new ListNodeCustom(num, current);

            prev.Next = newNode;
            _length++;
        }

        public double FindMedian()
        {
            var target = _length / 2;
            var index = 0;
            var current = _streamHead.Next;

            if (_length % 2 == 0)
            {
                target -= 1;
            }

            while (index < target)
            {
                current = current.Next;
                index++;
            }

            double median = current.Value;

            if (_length % 2 == 0)
            {
                median += current.Next.Value;
                median = median / 2.0;
            }

            return median;
        }
    }

    public class ListNodeCustom
    {
        public ListNodeCustom Next { get; set; }
        public int Value { get; set; }

        public ListNodeCustom(int val, ListNodeCustom next = null)
        {
            Value = val;
            Next = next;
        }
    }
}
