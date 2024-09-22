int[][] points = [[3,3],[5,-1],[-2,4]];
var k = 2;
var result = new Solution().KClosest(points, k);
foreach (var point in result)
{
    Console.WriteLine($"(X:{point[0]}, Y:{point[1]})");  // Output: (3,3), (-2,4)
}
public class Solution
{
    public int[][] KClosest(int[][] points, int k) 
    {
        PriorityQueue<int[], double> priorityQueue = new();
        for (int i = 0; i < points.Length; i++)
        {
            var point = points[i];
            var distance = Math.Sqrt(Math.Pow((point[0] - 0), 2) + Math.Pow((point[1] - 0),2));
            priorityQueue.Enqueue(point, distance);
        }
        int[][] result = new int[k][];
        for(int i = 0; i < k; i++)
        {
            result[i] = priorityQueue.Dequeue();
        }
        return result;
    }
}