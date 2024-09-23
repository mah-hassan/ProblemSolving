int[] nums = [1, 2];

Solution solution = new Solution();

int missingNumber = solution.MissingNumberUsingSorting(nums);

Console.WriteLine($"The missing number in the array is: {missingNumber}");

public class Solution {
    // Mathematical solution
    public int MissingNumber(int[] nums) {
        
        int expectedSum = nums.Length * (nums.Length + 1) / 2;
        
        return expectedSum - nums.Sum();
    }
    
    // Bitwise solution
    public int MissingNumberUsingSorting(int[] nums) {
        Array.Sort(nums);
        
        if (nums[0] != 0) return 0;

        for (int i = 0; i < nums.Length - 1; i++) {
            if(nums[i] != i) return i;
            if ((nums[i + 1] - nums[i]) > 1) return nums[i] + 1;
            
        }
        
        return nums[nums.Length - 1] + 1;
    }
}