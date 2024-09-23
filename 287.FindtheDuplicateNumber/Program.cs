int[] nums = [1,3,4,2,2];
// slow => 1 => 3 => 2 
// fast => 1 => 2 => 2 
// fast and slow meat again
// ptr => 1 => 3 => 2 
// slow => 2 => 4 => 2 
// both pointer and slow meat at 2 answer is 2
// imagine it as a cyclic linked list not an array
// where the start of cycle is the duplicate number 
var solution = new Solution();

var result = solution.FindDuplicate(nums);

Console.WriteLine($"The duplicate number is: {result}");

public class Solution {

    // Using Floyd’s Algorithm O(1) space and does not modefiy nums
    public int FindDuplicate(int[] nums) {
       
        int slow = nums[0], fast = nums[0];
        do
        {
            slow = nums[slow];
            fast = nums[nums[fast]];
        }while(fast != slow);

        int ptr = nums[0];

        while(ptr != slow)
        {
            ptr = nums[ptr];
            slow = nums[slow];
        }
       
        return slow;
    }
}