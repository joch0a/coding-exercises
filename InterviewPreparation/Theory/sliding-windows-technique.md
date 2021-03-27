# Sliding Window Algorithm

The **main idea behind the sliding window technique is to convert two nested loops into a single loop**. 
Usually, the technique helps us to reduce the time complexity from O(n^2) to O(n).

The technique lets us iterate over the array holding two pointers L and R. These pointers indicate the left and right ends of the current range. In each step, we either move L, R, or both of them to the next range.

In order to do this, we must be able to add elements to our current range when we move R forward. Also, we must be able to delete elements from our current range when moving L forward. Each time we reach a range, we calculate its answer from the elements we have inside the current range.

## When to use it?

The sliding window technique is useful when you need to keep track of a contiguous sequence of elements, such as summing up the values in a subarray

The following algorithm corresponds to the explained idea:

![alt text](https://www.baeldung.com/wp-content/ql-cache/quicklatex.com-9df819183fb413ae7d3c9b6c5e5fd43d_l3.svg)

## QUICK NOTE:
Although the algorithm may seem to have a O(n^2) complexity, let’s examine the algorithm carefully. The variable R always keeps its value. Therefore, it only moves forward until it reaches the value of n. Therefore, the number of times we execute the while loop in total is at most n times.

# Practice
- https://leetcode.com/problems/longest-substring-without-repeating-characters/

# Source: 
- https://levelup.gitconnected.com/understanding-the-sliding-window-technique-in-algorithms-c6c3bf8226da
- https://www.baeldung.com/cs/sliding-window-algorithm