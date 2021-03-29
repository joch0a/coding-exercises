# Backtracking

Backtracking is a general algorithm for finding all (or some) solutions to some computational problems (notably Constraint satisfaction problems or CSPs), which incrementally builds candidates to the solution and abandons a candidate ("backtracks") as soon as it determines that the candidate cannot lead to a valid solution. 

![alt text](https://assets.leetcode.com/uploads/2019/04/15/backtracking.png)

## General idea

Conceptually, one can imagine the procedure of backtracking as the tree traversal. Starting from the root node, one sets out to search for solutions that are located at the leaf nodes. Each intermediate node represents a partial candidate solution that could potentially lead us to a final valid solution. At each node, we would fan out to move one step further to the final solution, i.e. we iterate the child nodes of the current node. Once we can determine if a certain node cannot possibly lead to a valid solution, we abandon the current node and backtrack to its parent node to explore other possibilities. 

## Template

All backtracking problems are composed by these three steps: choose, explore, unchoose.
So for each problem, you need to know:
- **Choose what?**
- **How to explore?**
- **Unchoose**

Pseudocode
```C#
backtrack(candidate){
    if find_solution(candidate):
        output(candidate)
        return
    
    # iterate all possible candidates.
    for next_candidate in list_of_candidates:
        if is_valid(next_candidate):
            # try this partial candidate solution
            place(next_candidate)
            # given the candidate, explore further.
            backtrack(next_candidate)
            # backtrack
            remove(next_candidate)
```

### Here are a few notes about the above pseudocode.

Overall, the enumeration of candidates is done in two levels: 1). at the first level, the function is implemented as recursion. At each occurrence of recursion, the function is one step further to the final solution.  2). as the second level, within the recursion, we have an iteration that allows us to explore all the candidates that are of the same progress to the final solution.

The backtracking should happen at the level of the iteration within the recursion. 

Unlike brute-force search, in backtracking algorithms we are often able to determine if a partial solution candidate is worth exploring further (i.e. is_valid(next_candidate)), which allows us to prune the search zones. This is also known as the constraint, e.g. the attacking zone of queen in N-queen game. 

There are two symmetric functions that allow us to mark the decision (place(candidate)) and revert the decision (remove(candidate)). 

# Source
- https://leetcode.com/explore/featured/card/recursion-ii/472/backtracking/
- https://leetcode.com/problems/palindrome-partitioning/discuss/182307/Java:-Backtracking-Template-General-Approach
  