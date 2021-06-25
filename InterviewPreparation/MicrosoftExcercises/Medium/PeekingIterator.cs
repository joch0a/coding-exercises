using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class PeekingIterator
    {
        private IEnumerator<int> _iterator;
        private bool hasNext;

        // iterators refers to the first element of the array.
        public PeekingIterator(IEnumerator<int> iterator)
        {
            // initialize any member here.
            _iterator = iterator;
            hasNext = iterator.Current != null;
        }

        // Returns the next element in the iteration without advancing the iterator.
        public int Peek()
        {
            return _iterator.Current;
        }

        // Returns the next element in the iteration and advances the iterator.
        public int Next()
        {
            var current = _iterator.Current;

            hasNext = _iterator.MoveNext();

            return current;
        }

        // Returns false if the iterator is refering to the end of the array of true otherwise.
        public bool HasNext()
        {
            return hasNext;
        }
    }
}
