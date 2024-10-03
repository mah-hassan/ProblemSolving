var solution = new Solution();

int[] nums =  [2, 3, -2, 4];

int result = solution.MaxProduct(nums);

Console.WriteLine($"The maximum product of a contiguous subarray is: {result}");

public class Solution {
    public int MaxProduct(int[] nums) {
        int currMaxProduct = nums[0];
        int currMinProduct = nums[0];
        int result = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            int temp = currMaxProduct;
            currMaxProduct = Math.Max(nums[i], Math.Max(nums[i] * currMaxProduct, nums[i] * currMinProduct));
            currMinProduct = Math.Min(nums[i], Math.Min(nums[i] * temp, nums[i] * currMinProduct));
            result = Math.Max(result, currMaxProduct);
        }

        return result;
    }
}