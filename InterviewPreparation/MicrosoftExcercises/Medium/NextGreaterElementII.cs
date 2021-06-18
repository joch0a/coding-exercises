﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class NextGreaterElementII
    {
        public int[] NextGreaterElements(int[] nums)
        {
            var res = new int[nums.Length];
            var stack = new Stack<int>();
            Array.Fill(res, -1);

            for (int i = 0; i < nums.Length * 2; i++)
            {
                while (stack.Any() && nums[stack.Peek()] < nums[i % nums.Length])
                {
                    res[stack.Pop()] = nums[i % nums.Length];
                }

                if (i < nums.Length)
                {
                    stack.Push(i);
                }
            }

            return res;
        }
    }
}
