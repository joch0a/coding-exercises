using System;
using System.Linq;

namespace InterviewPreparation.TrainExercises.Easy
{
    class LicensePlate
    {
        //https://leetcode.com/problems/shortest-completing-word
        public string ShortestCompletingWord(string licensePlate, string[] words)
        {
            words = words.OrderBy(x => x.Length).ToArray();
            var wordLength = 0;
            int[] bucketLicense = new int[26];

            foreach (var character in licensePlate)
            {
                if (char.IsLetter(character))
                {
                    bucketLicense[char.ToLower(character) - 'a']++;
                    wordLength++;
                }
            }

            foreach (var word in words)
            {
                var coincidences = 0;
                int[] bucketWord = new int[26];

                foreach (var character in word)
                {
                    bucketWord[char.ToLower(character) - 'a']++;
                }

                for (int i = 0; i < bucketWord.Length; i++)
                {
                    if (bucketLicense[i] > 0 && bucketWord[i] > 0)
                    {
                        coincidences += Math.Min(bucketWord[i], bucketLicense[i]);
                    }

                    if (coincidences >= wordLength)
                    {
                        return word;
                    }
                }
            }


            return "";
        }
    }
}
