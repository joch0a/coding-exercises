using System.Collections.Generic;
using System.Linq;

namespace InterviewPreparation.MicrosoftExcercises.Hard
{
    class WordLadderII
    {
        //TLE
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            wordList.Add(beginWord);
            var shortests = new List<IList<string>>();
            var wordsDict = GenerateWordDictionary(wordList);
            var beginQueue = new Queue<List<string>>();

            beginQueue.Enqueue(new List<string>() { beginWord });

            while (beginQueue.Count > 0)
            {
                var initialQueueSize = beginQueue.Count;

                while (initialQueueSize > 0)
                {
                    var actualList = beginQueue.Dequeue();
                    var actual = actualList.Last();

                    if (actual == endWord)
                    {
                        shortests.Add(actualList);
                    }

                    EnqueueNeighbours(beginQueue, wordsDict, actual, actualList);

                    initialQueueSize--;
                }


                if (shortests.Count > 0)
                {
                    return shortests;
                }
            }

            return shortests;
        }

        private void EnqueueNeighbours(Queue<List<string>> queue,
                                       Dictionary<string, HashSet<string>> dict,
                                       string word,
                                       List<string> actualList)
        {
            for (int wordIndex = 0; wordIndex < word.Length; wordIndex++)
            {
                var left = word.Substring(0, wordIndex);
                var right = word.Substring(wordIndex + 1);
                var encoded = $"{left}*{right}";

                foreach (var neighbour in dict[encoded])
                {
                    var copy = actualList.ToList();

                    if (!copy.Contains(neighbour))
                    {
                        copy.Add(neighbour);
                        queue.Enqueue(copy);
                    }
                }
            }
        }

        private Dictionary<string, HashSet<string>> GenerateWordDictionary(IList<string> wordList)
        {
            var wordDict = new Dictionary<string, HashSet<string>>();

            foreach (var word in wordList)
            {
                for (int wordIndex = 0; wordIndex < word.Length; wordIndex++)
                {
                    var left = word.Substring(0, wordIndex);
                    var right = word.Substring(wordIndex + 1);
                    var encoded = $"{left}*{right}";

                    if (!wordDict.ContainsKey(encoded))
                    {
                        wordDict.Add(encoded, new HashSet<string>());
                    }

                    wordDict[encoded].Add(word);
                }
            }

            return wordDict;
        }

        public IList<IList<string>> FindLaddersReview(string beginWord, string endWord, IList<string> wordList)
        {
            var res = new List<IList<string>>();
            var wordSet = wordList.ToHashSet();

            if (!wordSet.Contains(endWord) || beginWord.Length != endWord.Length)
            {
                return res;
            }

            var queue = new Queue<List<string>>();
            var path = new List<string>() { beginWord };
            var visited = new HashSet<string>();
            var found = false;

            queue.Enqueue(path);

            while (queue.Count > 0)
            {
                var queueSize = queue.Count;

                while (queueSize > 0)
                {
                    var actualList = queue.Dequeue();
                    var current = actualList.Last();
                    var currentArray = current.ToArray();

                    for (int i = 0; i < current.Length; i++)
                    {
                        var originalChar = current[i];

                        for (char c = 'a'; c <= 'z'; c++)
                        {
                            currentArray[i] = c;
                            var next = new string(currentArray);

                            if (wordSet.Contains(next))
                            {
                                visited.Add(next);
                                actualList.Add(next);

                                if (next == endWord)
                                {
                                    found = true;
                                    res.Add(new List<string>(actualList));
                                }

                                queue.Enqueue(new List<string>(actualList));
                                actualList.RemoveAt(actualList.Count - 1);
                            }
                        }

                        currentArray[i] = originalChar;
                    }

                    queueSize--;
                }

                foreach (var str in visited)
                {
                    wordSet.Remove(str);
                }

                if (found)
                {
                    break;
                }
            }

            return res;
        }
    }
}
