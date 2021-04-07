# Prefix Sum Array

## Description 

Given an array arr[] of size n, its prefix sum array is another array prefixSum[] of same size such that the value of prefixSum[i] is arr[0] + arr[1] + arr[2] … arr[i].

```C#
 static void fillPrefixSum(int[] arr, int n,
                              int[] prefixSum)
    {
        prefixSum[0] = arr[0];
 
        // Adding present element
        // with previous element
        for (int i = 1; i < n; ++i)
            prefixSum[i] = prefixSum[i - 1] + arr[i];
    }
```

## Applications

- **Equilibrium index of an array :** Equilibrium index of an array is an index such that the sum of elements at lower indexes is equal to the sum of elements at higher indexes.
- **Find if there is a subarray with 0 sum :** Given an array of positive and negative numbers, find if there is a subarray (of size at-least one) with 0 sum.
- **Maximum subarray size, such that all subarrays of that size have sum less than k :** Given an array of n positive integers and a positive integer k, the task is to find the maximum subarray size such that all subarrays of that size have sum of elements less than k.
- **Find the prime numbers which can written as sum of most consecutive primes :** Given an array of limits. For every limit, find the prime number which can be written as the sum of the most consecutive primes smaller than or equal to limit.
- **Longest Span with same Sum in two Binary arrays :** Given two binary arrays arr1[] and arr2[] of same size n. Find length of the longest common span (i, j) where j >= i such that arr1[i] + arr1[i+1] + …. + arr1[j] = arr2[i] + arr2[i+1] + …. + arr2[j].
- **Maximum subarray sum modulo m :** Given an array of n elements and an integer m. The task is to find the maximum value of the sum of its subarray modulo m i.e find the sum of each subarray mod m and print the maximum value of this modulo operation.
- **Maximum subarray size, such that all subarrays of that size have sum less than k :** Given an array of n positive integers and a positive integer k, the task is to find the maximum subarray size such that all subarrays of that size have sum of elements less than k.
- **Maximum occurred integer in n ranges :** Given n ranges of the form L and R, the task is to find the maximum occurred integer in all the ranges. If more than one such integer exits, print the smallest one.
- **Minimum cost for acquiring all coins with k extra coins allowed with every coin :** You are given a list of N coins of different denominations. you can pay an amount equivalent to any 1 coin and can acquire that coin. In addition, once you have paid for a coin, we can choose at most K more coins and can acquire those for free. The task is to find the minimum amount required to acquire all the N coins for a given value of K.
- **Random number generator in arbitrary probability distribution fashion :** Given n numbers, each with some frequency of occurrence. Return a random number with probability proportional to its frequency of occurrence.