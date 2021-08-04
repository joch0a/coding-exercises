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
    }
}
