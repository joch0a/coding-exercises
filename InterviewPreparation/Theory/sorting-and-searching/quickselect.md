
# QuickSelect

## Motivation

Quickselect is a selection algorithm to find the k-th smallest element in an unordered list. It is related to the quick sort sorting algorithm.

The algorithm is similar to QuickSort. The difference is, instead of recurring for both sides (after finding pivot), it recurs only for the part that contains the k-th smallest element. The logic is simple, if index of partitioned element is more than k, then we recur for left part. If index is same as k, we have found the k-th smallest element and we return. If index is less than k, then we recur for right part. This reduces the expected complexity from O(n log n) to **O(n)**, with a worst case of O(n^2).

## Pseudocode

```
    function quickSelect(list, left, right, k)

       if left = right
          return list[left]

       Select a pivotIndex between left and right

       pivotIndex := partition(list, left, right, 
                                      pivotIndex)
       if k = pivotIndex
          return list[k]
       else if k < pivotIndex
          right := pivotIndex - 1
       else
          left := pivotIndex + 1 
```

C# Implementation

```C#
 static int partitions(int []arr,int low, int high)
    {
        int pivot = arr[high], pivotloc = low, temp;
        for (int i = low; i <= high; i++)
        {
            // inserting elements of less value
            // to the left of the pivot location
            if(arr[i] < pivot)
            {        
                temp = arr[i];
                arr[i] = arr[pivotloc];
                arr[pivotloc] = temp;
                pivotloc++;
            }
        }
         
        // swapping pivot to the readonly pivot location
        temp = arr[high];
        arr[high] = arr[pivotloc];
        arr[pivotloc] = temp;
         
        return pivotloc;
    }
     
    // finds the kth position (of the sorted array)
    // in a given unsorted array i.e this function
    // can be used to find both kth largest and
    // kth smallest element in the array.
    // ASSUMPTION: all elements in []arr are distinct
    static int kthSmallest(int[] arr, int low,
                                int high, int k)
    {
        // find the partition
        int partition = partitions(arr,low,high);
 
        // if partition value is equal to the kth position,
        // return value at k.
        if(partition == k)
            return arr[partition];
             
        // if partition value is less than kth position,
        // search right side of the array.
        else if(partition < k )
            return kthSmallest(arr, partition + 1, high, k );
             
        // if partition value is more than kth position,
        // search left side of the array.
        else
            return kthSmallest(arr, low, partition - 1, k );        
    }
```

# Source
  - https://www.geeksforgeeks.org/quickselect-algorithm/
  - 