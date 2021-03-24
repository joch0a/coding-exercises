# Tree Traversals (Inorder, Preorder and Postorder)

![alt text](https://media.geeksforgeeks.org/wp-content/cdn-uploads/2009/06/tree12.gif)

## Depth First Traversals: 
### Inorder (Left, Root, Right) : 4 2 5 1 3 
### Preorder (Root, Left, Right) : 1 2 4 5 3 
### Postorder (Left, Right, Root) : 4 5 2 3 1

## Inorder Traversal
```
    Algorithm Inorder(tree)
       1. Traverse the left subtree, i.e., call Inorder(left-subtree)
       2. Visit the root.
       3. Traverse the right subtree, i.e., call Inorder(right-subtree)
```

## Preorder Traversal 
```
    Algorithm Preorder(tree)
       1. Visit the root.
       2. Traverse the left subtree, i.e., call Preorder(left-subtree)
       3. Traverse the right subtree, i.e., call Preorder(right-subtree) 
```

## Postorder Traversal
```
    Algorithm Postorder(tree)
       1. Traverse the left subtree, i.e., call Postorder(left-subtree)
       2. Traverse the right subtree, i.e., call Postorder(right-subtree)
       3. Visit the root.
```

## Rule of thumb of when to use each strategy

The traversal strategy the programmer selects depends on the specific needs of the algorithm being designed. The goal is speed, so pick the strategy that brings you the nodes you require the fastest.

If you know you **need to explore the roots before inspecting any leaves**, you pick **pre-order** because you will encounter all the roots before all of the leaves.

If you know you need to **explore all the leaves before any nodes**, you select **post-order** because you don't waste any time inspecting roots in search for leaves.

If you know that the **tree has an inherent sequence in the nodes**, and **you want to flatten the tree back into its original sequence**, than an **in-order** traversal should be used. 

The tree would be flattened in the same way it was created. A pre-order or post-order traversal might not unwind the tree back into the sequence which was used to create it.

## Inorder Tree Traversal without Recursion

```
    1) Create an empty stack S.
    2) Initialize current node as root
    3) Push the current node to S and set current = current->left until current is NULL
    4) If current is NULL and stack is not empty then 
         a) Pop the top item from stack.
         b) Print the popped item, set current = popped_item->right 
         c) Go to step 3.
    5) If current is NULL and stack is empty then we are done.
```

```C#
    public virtual void inorder()
    {
        if (root == null)
        {
            return;
        }
 
        Stack<Node> s = new Stack<Node>();
        Node curr = root;
 
        while (curr != null || s.Count > 0)
        {
            while (curr != null)
            {
                s.Push(curr);
                curr = curr.left;
            }
 
            curr = s.Pop();
 
            //Do stuff
 
            curr = curr.right;
        }
    }
```

## Iterative Postorder Traversal

```
    1.1 Create an empty stack
    2.1 Do following while root is not NULL
        a) Push root's right child and then root to stack.
        b) Set root as root's left child.
    2.2 Pop an item from stack and set it as root.
        a) If the popped item has a right child and the right child 
           is at top of stack, then remove the right child from stack,
           push the root back and set root as root's right child.
        b) Else print root's data and set root as NULL.
    2.3 Repeat steps 2.1 and 2.2 while stack is not empty.
```

```C#
public class BinaryTree
{
    Node root;
    List<int> list = new List<int>();
 
    List<int> postOrderIterative(Node node)
    {
        Stack<Node> S = new Stack<Node>();
 
        // Check for empty tree
        if (node == null)
            return list;
        S.Push(node);
        Node prev = null;

        while (S.Count != 0)
        {
            Node current = S.Peek();
 
            /* go down the tree in search of a leaf an if so process it
                and pop stack otherwise move down */
            if (prev == null || prev.left == current ||
                prev.right == current)
            {
            if (current.left != null)
                S.Push(current.left);
            else if (current.right != null)
                S.Push(current.right);
            else
            {
                S.Pop();
                list.Add(current.data);
            }
 
            /* go up the tree from left node, if the child is right
                    push it onto stack otherwise process parent and pop
                    stack */
            }
            else if (current.left == prev)
            {
            if (current.right != null)
                S.Push(current.right);
            else
            {
                S.Pop();
                list.Add(current.data);
            }
 
            /* go up the tree from right node and after coming back
                    from right node process parent and pop stack */
            }
            else if (current.right == prev)
            {
            S.Pop();
            list.Add(current.data);
            }
 
            prev = current;
        }

    return list;
}
```

## Iterative Preorder Traversal

```
    1) Create an empty stack nodeStack and push root node to stack. 
    2) Do following while nodeStack is not empty. 
        a) Pop an item from stack and print it. 
        b) Push right child of popped item to stack 
        c) Push left child of popped item to stack
```

```C#
    public Node root;
 
    public virtual void iterativePreorder()
    {
        iterativePreorder(root);
    }

    public virtual void iterativePreorder(Node node)
    {
 
        if (node == null) {
            return;
        }
 
        Stack<Node> nodeStack = new Stack<Node>();
        nodeStack.Push(root);
 
        while (nodeStack.Count > 0) {
            Node mynode = nodeStack.Peek();

            // Do stuff

            nodeStack.Pop();
 

            if (mynode.right != null) {
                nodeStack.Push(mynode.right);
            }

            if (mynode.left != null) {
                nodeStack.Push(mynode.left);
            }
        }
    }

```

# Source: 
- https://www.geeksforgeeks.org/tree-traversals-inorder-preorder-and-postorder/
- https://www.geeksforgeeks.org/inorder-tree-traversal-without-recursion/
- https://www.geeksforgeeks.org/iterative-postorder-traversal-using-stack/
- https://stackoverflow.com/a/17658699