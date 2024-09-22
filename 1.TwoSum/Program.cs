int[] nums = { 2, 3, 11, 3 };
int target = 6;

var solution = new Solution();

var result = solution.TwoSum(nums, target);

if (result.Length > 0)
{
    Console.WriteLine($"The indices of the two numbers that add up to {target} are: {result[0]}, {result[1]}");
}
else
{
    Console.WriteLine("No two numbers add up to the target.");
}

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> hashMap = new();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];
            if(!hashMap.ContainsKey(complement))
            {
                hashMap[nums[i]] = i;
                complement = 0;
            }
            else
            {
                return [ i, hashMap[complement]];
            }
           
        }
        return Array.Empty<int>();
    }
}