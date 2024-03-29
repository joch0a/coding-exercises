﻿using System;
using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Hard
{
    class LongestValidParentheses
    {
        public int LongestValidParenthesesBRUTEFORCE(string str)
        {
            int max = 0;
            var currentValidLength = -1;
            var currentIndex = 0;
            while (currentIndex < str.Length)
            {
                if (str[currentIndex] == '(')
                {
                    currentValidLength = CalculateLongestValidParentheses(currentIndex, str);
                    max = Math.Max(max, currentValidLength);
                }

                if (currentValidLength != -1)
                {
                    currentIndex += currentValidLength;
                    currentValidLength = -1;
                }
                else
                {
                    currentIndex++;
                }
            }

            return max;
        }

        private int CalculateLongestValidParentheses(int startIndex, string str)
        {
            var currentLength = 1;
            var longest = -1;
            var stack = new Stack<char>();
            var currentIndex = startIndex + 1;
            var isValid = true;

            stack.Push(str[startIndex]);

            while (currentIndex < str.Length && isValid)
            {
                var actual = str[currentIndex];

                if (actual == ')' && stack.Count == 0)
                {
                    isValid = false;
                }

                else if (actual == '(')
                {
                    currentLength++;
                    stack.Push(actual);
                }
                else //actual == ')'
                {
                    currentLength++;
                    stack.Pop();

                    if (stack.Count == 0)
                    {
                        longest = currentLength;
                    }
                }

                currentIndex++;
            }

            return longest;
        }
        /// <summary>
        /// ////////////////////////
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int LongestValidParenthesesUSINGSTACK(string str)
        {
            var stack = new Stack<int>();
            var max = 0;
            stack.Push(-1);

            for (int i = 0; i < str.Length; i++)
            {
                var actual = str[i];

                if (actual == '(')
                {
                    stack.Push(i);
                }
                else
                {
                    stack.Pop();

                    if (stack.Count == 0)
                    {
                        stack.Push(i);
                    }
                    else
                    {
                        max = Math.Max(max, i - stack.Peek());
                    }
                }
            }

            return max;
        }

        //dp 

        public int LongestValidParenthesesDP(string s)
        {
            var dp = new int[s.Length];
            var max = 0;

            for (int i = 1; i < s.Length; i++) 
            {
                if (s[i] == ')') 
                {
                    if (s[i - 1] == '(')
                    {
                        dp[i] = dp[i - 1] + (i >= 2 ? dp[i - 2] : 0) + 2;
                    }
                    else if(i - dp[i - 1] > 0 && s[i - dp[i - 1] - 1] == '(')
                    {
                        dp[i] = dp[i - 1] + (i - dp[i - 1] >= 2 ? dp[i - dp[i - 1] - 2] : 0) + 2;
                    }

                    max = Math.Max(max, dp[i]);
                }
            }

            return max;
        }
    }
}
