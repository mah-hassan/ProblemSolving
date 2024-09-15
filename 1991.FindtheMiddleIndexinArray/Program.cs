
int[] nums = [2, 3, -1, 8, 4];
var middle = new Solution().FindMiddleIndex(nums);
Console.WriteLine(middle);
public class Solution
{
    public int FindMiddleIndex(int[] nums)
    {
        int totalSum = nums.Sum(), leftSum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (leftSum == totalSum - leftSum - nums[i])
            {
                return i;
            }
            leftSum += nums[i];
        }
        return -1;
    }
}