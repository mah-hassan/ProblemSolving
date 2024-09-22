using System.Collections;

var solution = new Solution();
int[] nums = [2,3,4,1,4,0,4,-1,-2,-1];
int k = 2;
var result = solution.TopKFrequent(nums, k);
Console.WriteLine($"the top frequent {k} numbers is:");
Console.Write("[ ");
foreach (var num in result)
{
    Console.Write(num + " ");
}
Console.Write("]");
public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        Dictionary<int, int> frequancyMap = new();
        foreach (var num in nums)
        {
            if (frequancyMap.ContainsKey(num))
            {
                frequancyMap[num]++;
            }
            else
            {
                frequancyMap[num] = 1;
            }
        }
        PriorityQueue<int, int> priorityQueue = new(FrequancyComparer.Instance);
        foreach (var item in frequancyMap)
        {
            priorityQueue.Enqueue(item.Key, item.Value);
        }
        int[] result = new int[k];
        for (int i = 0; i < k; i++)
        {
            result[i] = priorityQueue.Dequeue();
        }
        return result;
    }
}
// override buit in PriorityQueue int comparer to give high priority to large value not small
public class FrequancyComparer : IComparer<int>
{
    private FrequancyComparer()
    {
        
    }
    public static FrequancyComparer Instance { get; } = new FrequancyComparer();
    public int Compare(int x, int y)
    {
        return x > y ? -1 : x < y ? 1 : 0;
    }
}