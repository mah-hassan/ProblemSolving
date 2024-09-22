using System.Collections;

var solution = new Solution();
int[] nums = [2,3,4,1,4,0,4,-1,-2,-1];
int k = 2;
var result = solution.FindKthLargest(nums, k);

Console.WriteLine($"The {k}th largest number is: {result}");

public class Solution {

    public int FindKthLargest(int[] nums, int k) {
        MinHeap minHeap = new MinHeap(k);
        for (int i = 0; i < k; i++) {
            minHeap.Insert(nums[i]);
        }
        
        for (int i = k; i < nums.Length; i++) {
            if (nums[i] > minHeap.Peek()) {
                minHeap.Pop();
                minHeap.Insert(nums[i]);
            }
        }
        
        return minHeap.Peek();
    }
    // public int FindKthLargest(int[] nums, int k) 
    // {
    //     PriorityQueue<int, int> priorityQueue = new();
    //     // by default PriorityQueue in C# is buit on top of binary heap
    //     foreach (var num in nums)
    //     {
    //         priorityQueue.Enqueue(num, num);
    //         if (priorityQueue.Count > k)
    //             priorityQueue.Dequeue();
    //     }
        
    //     return priorityQueue.Peek();
    // } 
}
public class MinHeap {
    private int[] heap;
    private int size;

    public MinHeap(int capacity) {
        heap = new int[capacity];
        size = 0;
    }

    public void Insert(int val) {
        heap[size] = val;
        size++;
        BubbleUp();
    }

    public int Peek() {
        return heap[0];
    }

    public int Pop() {
        int poppedValue = heap[0]; 
        heap[0] = heap[size - 1];
        size--;
        BubbleDown();
        return poppedValue;
    }

    private void BubbleUp() {

        int index = size - 1;
        while (index > 0 && heap[index] < heap[Parent(index)]) {
            Swap(index, Parent(index));
            index = Parent(index);
        }
    }

    private void BubbleDown() {
        int index = 0;
        while (HasLeftChild(index) && (heap[index] > LeftChild(index) || HasRightChild(index) && heap[index] > RightChild(index))) {
            int smallerChildIndex = LeftChildIndex(index);
            if (HasRightChild(index) && RightChild(index) < LeftChild(index)) {
                smallerChildIndex = RightChildIndex(index);
            }
            Swap(index, smallerChildIndex);
            index = smallerChildIndex;
        }
    }

    private int Parent(int index) => (index - 1) / 2;
    private int LeftChildIndex(int index) => 2 * index + 1;
    private int RightChildIndex(int index) => 2 * index + 2;

    private bool HasLeftChild(int index) => LeftChildIndex(index) < size;
    private bool HasRightChild(int index) => RightChildIndex(index) < size;

    private int LeftChild(int index) => heap[LeftChildIndex(index)];
    private int RightChild(int index) => heap[RightChildIndex(index)];

    private void Swap(int indexOne, int indexTwo) {
        int temp = heap[indexOne];
        heap[indexOne] = heap[indexTwo];
        heap[indexTwo] = temp;
    }
}