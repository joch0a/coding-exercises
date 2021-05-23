# Pattern searching

Pattern searching is an important problem in computer science. When we do search for a string in notepad/word file or browser or database, pattern searching algorithms are used to show the search results.

## KMP Complexity vs Naive approach

The worst case complexity of the Naive algorithm is **O(m(n-m+1))**. The time complexity of KMP algorithm is **O(n)** in the worst case.

## Overview

The KMP matching algorithm uses degenerating property (pattern having same sub-patterns appearing more than once in the pattern) of the pattern and improves the worst case complexity to O(n). The basic idea behind KMP’s algorithm is: whenever we detect a mismatch (after some matches), we already know some of the characters in the text of the next window. We take advantage of this information to avoid matching the characters that we know will anyway match. Let us consider below example to understand this.

## Preprocessing Overview:

- KMP algorithm preprocesses pat[] and constructs an auxiliary lps[] of size m (same as size of pattern) which is used to skip characters while matching.
- Name lps indicates longest proper prefix which is also suffix.. A proper prefix is prefix with whole string not allowed. For example, prefixes of “ABC” are “”, “A”, “AB” and “ABC”. Proper prefixes are “”, “A” and “AB”. Suffixes of the string are “”, “C”, “BC” and “ABC”.
- We search for lps in sub-patterns. More clearly we focus on sub-strings of patterns that are either prefix and suffix.
- **For each sub-pattern pat[0..i] where i = 0 to m-1, lps[i] stores length of the maximum match
  ing proper prefix which is also a suffix of the sub-pattern pat[0..i].**

# LPS Creation code

```C#
void computeLPSArray(char *pat, int M, int *lps)
  {
      int len = 0;  // lenght of the previous longest prefix suffix
      int i;

      lps[0] = 0; // lps[0] is always 0
      i = 1;

      // the loop calculates lps[i] for i = 1 to M-1
      while (i < M)
      {
         //example "abababca" and i==5, len==3. The longest prefix suffix is "aba", when pat[i]==pat[len],
         //we get new prefix "abab" and new suffix "abab", so increase length of  current lps by 1 and go to next iteration. 
         if (pat[i] == pat[len])
         {
           len++;
           lps[i] = len;
           i++;
         }
         else // (pat[i] != pat[len])
         {
           if (len != 0)
           {
             len = lps[len-1];
             //This is tricky. Consider the example "ababe......ababc", i is index of 'c', len==4. The longest prefix suffix is "abab",
             //when pat[i]!=pat[len], we get new prefix "ababe" and suffix "ababc", which are not equal. 
             //This means we can't increment length of lps based on current lps "abab" with len==4. We may want to increment it based on
             //the longest prefix suffix with length < len==4, which by definition is lps of "abab". So we set len to lps[len-1],
             //which is 2, now the lps is "ab". Then check pat[i]==pat[len] again due to the while loop, which is also the reason
             //why we do not increment i here. The iteration of i terminate until len==0 (didn't find lps ends with pat[i]) or found
             //a lps ends with pat[i].
           }
           else // if (len == 0)
           { // there isn't any lps ends with pat[i], so set lps[i] = 0 and go to next iteration.
             lps[i] = 0;
             i++;
           }
         }
      }
  }  
```

## How to use lps[] to decide next positions

- We start comparison of pat[j] with j = 0 with characters of current window of text.
- We keep matching characters txt[i] and pat[j] and keep incrementing i and j while pat[j] and txt[i] keep matching.
- **When we see a mismatch**
  - We know that characters pat[0..j-1] match with txt[i-j…i-1] (Note that j starts with 0 and increment it only when there is a match).
  - We also know (from above definition) that lps[j-1] is count of characters of pat[0…j-1] that are both proper prefix and suffix.
    - From above two points, we can conclude that we do not need to match these lps[j-1] characters with txt[i-j…i-1] because we know that these characters will anyway match.
    - j = lps[j-1]

# Source
- https://leetcode.com/problems/implement-strstr/discuss/13160/detailed-explanation-on-building-up-lps-for-kmp-algorithm
- https://www.geeksforgeeks.org/kmp-algorithm-for-pattern-searching/