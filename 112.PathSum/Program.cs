public class TreeNode {
    public int val;
    public TreeNode? left;
    public TreeNode? right;
    public TreeNode(int val=0, TreeNode? left = null, TreeNode? right = null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
public class Solution {
    public bool HasPathSum(TreeNode root, int targetSum) 
    {
        if(root is null) return false;    
        return HasPathSum(root, targetSum, 0);  
    }
    private bool HasPathSum(TreeNode root, int targetSum, int currentSum)
    {
        currentSum = currentSum + root.val;
        if(root.left is null && root.right is null) return currentSum == targetSum;

        bool leftPathSum = root.left is not null ? HasPathSum(root.left, targetSum, currentSum) : false;
        if(leftPathSum) return leftPathSum; // if we found it return do not check the right path
        bool rightPathSum = root.right is not null ? HasPathSum(root.right, targetSum, currentSum) : false;
        return leftPathSum || rightPathSum;
    }
 
}