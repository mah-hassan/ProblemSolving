int[] nums1 = [2];

int[] nums2 = [1, 3];

double median = new Solution().FindMedianSortedArrays(nums1, nums2);

Console.WriteLine(median); // Output: 2.0
public class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        // Ensure nums1 is the smaller array
        if (nums1.Length > nums2.Length)
            return FindMedianSortedArrays(nums2, nums1);

        int a = nums1.Length;
        int b = nums2.Length;
        int half = (a + b + 1) / 2; 
        int low = 0, high = a;

        while (low <= high)
        {
            int partitionX = (low + high) / 2;
            int partitionY = half - partitionX;

            int maxLeftX = partitionX == 0 ? int.MinValue : nums1[partitionX - 1];
            int minRightX = partitionX == a ? int.MaxValue : nums1[partitionX];

            int maxLeftY = partitionY == 0 ? int.MinValue : nums2[partitionY - 1];
            int minRightY = partitionY == b ? int.MaxValue : nums2[partitionY];

            if (maxLeftX <= minRightY && maxLeftY <= minRightX)
            {
                // If the total length is odd, return the max of left halves
                if ((a + b) % 2 == 1)
                {
                    return Math.Max(maxLeftX, maxLeftY);
                }
                // If the total length is even, return the average of the middle two numbers
                return (Math.Max(maxLeftX, maxLeftY) + Math.Min(minRightX, minRightY)) / 2.0;
            }
            else if (maxLeftX > minRightY)
            {
                high = partitionX - 1; 
            }
            else
            {
                low = partitionX + 1; 
            }
        }

       return -1;
    }
}