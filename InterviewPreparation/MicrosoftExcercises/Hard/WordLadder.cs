using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Hard
{
    public class WordLadder
    {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            if (!wordList.Contains(endWord) || beginWord == endWord)
            {
                return 0;
            }
            wordList.Add(beginWord);
            var wordSet = CreateWordSet(wordList);
            var queue = new Queue<string>();
            var visited = new HashSet<string>();
            var visitedEnd = new HashSet<string>();
            var startQueueLevel = 0;
            queue.Enqueue(beginWord);

            var endQueueLevel = 0;
            var endQueue = new Queue<string>();

            endQueue.Enqueue(endWord);

            while (queue.Count > 0 && endQueue.Count > 0)
            {
                var queueSize = queue.Count;
                var endQueueSize = endQueue.Count;

                startQueueLevel++;

                while (queueSize > 0)
                {
                    var actual = queue.Dequeue();

                    if (visitedEnd.Contains(actual))
                    {
                        return endQueueLevel + startQueueLevel - 1;
                    }

                    if (!visited.Contains(actual))
                    {
                        visited.Add(actual);
                        EnqueueNeighbours(actual, wordSet, visited, queue);
                    }

                    queueSize--;
                }

                endQueueLevel++;

                while (endQueueSize > 0)
                {
                    var actual = endQueue.Dequeue();


                    if (visited.Contains(actual))
                    {
                        return endQueueLevel + startQueueLevel - 1;
                    }

                    if (!visitedEnd.Contains(actual))
                    {
                        visitedEnd.Add(actual);
                        EnqueueNeighbours(actual, wordSet, visitedEnd, endQueue);
                    }

                    endQueueSize--;
                }

            }

            return 0;
        }

        private Dictionary<string, HashSet<string>> CreateWordSet(IList<string> wordList)
        {
            var wordSet = new Dictionary<string, HashSet<string>>();

            foreach (var currentWord in wordList)
            {
                for (int i = 0; i < currentWord.Length; i++)
                {
                    var leftSide = currentWord.Substring(0, i);
                    var rightSide = currentWord.Substring(i + 1);
                    var encoded = $"{leftSide}*{rightSide}";

                    if (!wordSet.ContainsKey(encoded))
                    {
                        wordSet.Add(encoded, new HashSet<string>());
                    }

                    wordSet[encoded].Add(currentWord);
                }
            }

            return wordSet;
        }

        private void EnqueueNeighbours(string actual,
                                       Dictionary<string, HashSet<string>> wordSet,
                                       HashSet<string> visited,
                                       Queue<string> queue)
        {
            for (int i = 0; i < actual.Length; i++)
            {
                var leftSide = actual.Substring(0, i);
                var rightSide = actual.Substring(i + 1);
                var encoded = $"{leftSide}*{rightSide}";

                if (wordSet.ContainsKey(encoded))
                {
                    foreach (var word in wordSet[encoded])
                    {
                        if (!visited.Contains(word))
                        {
                            queue.Enqueue(word);
                        }
                    }
                }
            }
        }
    }

}
