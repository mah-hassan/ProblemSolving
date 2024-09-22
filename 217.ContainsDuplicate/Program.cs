int[]  nums = [1,2,3,4];

var solution = new Solution();

var result = solution.ContainsDuplicate(nums);

Console.WriteLine($"The array contains duplicate numbers: {result}");

public class Solution {
    public bool ContainsDuplicate(int[] nums) {

        HashSet<int> uniqeNums = new HashSet<int>();

        foreach (var num in nums)
            if(!uniqeNums.Add(num))
                return true;

        return false;
    }
}