public class Solution
{
    // O(N * M)
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        int[] result = new int[nums1.Length];
        for (int i = 0; i < nums1.Length; i++)
        {
            for (int j = 0; j < nums2.Length; j++)
            {
                if (nums1[i] == nums2[j])
                {
                    for (int k = j + 1; k < nums2.Length; k++)
                        if (nums2[k] > nums1[i])
                        {
                            result[i] = nums2[k];
                            break;
                        }
                    if(result[i] == 0)
                    {
                        result[i] = -1;
                    }
                    break;
                }               
            }
        }
        return result;
    }
    // Using monotonic stack O(N + M)
    public int[] NextGreaterElementV2(int[] nums1, int[] nums2)
    {
        Stack<int> monotonicStack = new();
        Dictionary<int, int> nextGreatersMap = new();
        for(int i = nums2.Length - 1; i >= 0; i--)
        {
            int curr = nums2[i];
            while(monotonicStack.Count > 0 && monotonicStack.Peek() <= curr)
            {
                monotonicStack.Pop();
            }

            if(monotonicStack.Count > 0)
                nextGreatersMap[curr] = monotonicStack.Peek();
            else
                nextGreatersMap[curr] = -1;

            monotonicStack.Push(curr);
        }

        int[] result = new int[nums1.Length];

        for(int i = 0; i < nums1.Length; i++)
        {
            result[i] = nextGreatersMap[nums1[i]];
        }

        return result;
    }
}