using System;
using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Hard
{
    public class TrappingRainWater
    {
        public int Trap(int[] heights)
        {
            var total = 0;
            var stack = new Stack<IndexedHeight>(); // [index, height]

            for (int i = 0; i < heights.Length; i++)
            {
                var actual = new IndexedHeight(i, heights[i]);

                if (stack.Count == 0 && actual.Height == 0)
                {
                    continue;
                }

                var trappedLength = 0;
                var diff = 0;

                while (stack.Count > 0 && actual.Height > stack.Peek().Height)
                {
                    var prev = stack.Pop();

                    if (stack.Count == 0)
                    {
                        break;
                    }

                    trappedLength = actual.Index - stack.Peek().Index - 1;
                    diff = Math.Min(actual.Height, stack.Peek().Height) - prev.Height;

                    total += trappedLength * diff;
                }

                stack.Push(actual);
            }

            return total;
        }
    }

    public class IndexedHeight
    {
        public int Index { get; set; }

        public int Height { get; set; }

        public IndexedHeight(int index, int height)
        {
            Index = index;
            Height = height;
        }
    }
}
