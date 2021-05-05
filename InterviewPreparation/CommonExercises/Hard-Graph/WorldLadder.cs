using System.Collections.Generic;

namespace InterviewPreparation.CommonExercises.Hard_Graph
{
    class WorldLadder
    {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            var dict = new Dictionary<string, HashSet<string>>();
            var allCombinations = new Dictionary<string, HashSet<string>>();
            var visited = new HashSet<string>();
            var endVisited = new HashSet<string>();
            var containsEndWord = false;

            AddCombinations(dict, allCombinations, beginWord);

            foreach (var word in wordList)
            {
                if (word == endWord)
                {
                    containsEndWord = true;
                }

                AddCombinations(dict, allCombinations, word);
            }


            if (!containsEndWord)
            {
                return 0;
            }

            var queue = new Queue<string>();
            var level = 0;

            var endQueue = new Queue<string>();
            var endLevel = 0;

            queue.Enqueue(beginWord);
            endQueue.Enqueue(endWord);

            while (queue.Count > 0 && endQueue.Count > 0)
            {
                level++;

                var queueSize = queue.Count;
                var endQueueSize = endQueue.Count;

                while (queueSize > 0)
                {
                    var actual = queue.Dequeue();

                    if (endVisited.Contains(actual))
                    {
                        return level + endLevel - 1;
                    }

                    if (!visited.Contains(actual))
                    {
                        visited.Add(actual);

                        foreach (var combination in allCombinations[actual])
                        {
                            foreach (var word in dict[combination])
                            {
                                if (!visited.Contains(word))
                                {
                                    queue.Enqueue(word);
                                }
                            }
                        }
                    }

                    queueSize--;
                }

                endLevel++;

                while (endQueueSize > 0)
                {
                    var actual = endQueue.Dequeue();

                    if (visited.Contains(actual))
                    {
                        return level + endLevel - 1;
                    }

                    if (!endVisited.Contains(actual))
                    {
                        endVisited.Add(actual);

                        foreach (var combination in allCombinations[actual])
                        {
                            foreach (var word in dict[combination])
                            {
                                if (!endVisited.Contains(word))
                                {
                                    endQueue.Enqueue(word);
                                }
                            }
                        }
                    }

                    endQueueSize--;
                }
            }

            return 0;
        }

        public void AddCombinations(Dictionary<string, HashSet<string>> dict, Dictionary<string, HashSet<string>> allCombinations, string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                var modified = $"{word.Substring(0, i)}*{word.Substring(i + 1, word.Length - i - 1)}";

                if (!dict.ContainsKey(modified))
                {
                    dict.Add(modified, new HashSet<string>());
                }

                if (!allCombinations.ContainsKey(word))
                {
                    allCombinations.Add(word, new HashSet<string>());
                }

                allCombinations[word].Add(modified);
                dict[modified].Add(word);
            }
        }
    }
}
