
using System.Diagnostics;

TreeNode root = new(1)
{
    left = new(2)
    {
        left = new(4),
        right = new(5),
    },
    right = new(3) 
};
var solution = new Solution();

int result = solution.DiameterOfBinaryTree(root);

Console.WriteLine($"The diameter of the binary tree is: {result}");  
[DebuggerDisplay(nameof(TreeNode.val))]
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
    // Using Recursive DFS
    public int DiameterOfBinaryTree(TreeNode root) {
        int maxDiameter = 0;

        int DFS(TreeNode? root)
        {
            if(root is null) return 0;
            
            int leftHeight = DFS(root.left);
            int rightHeight = DFS(root.right);
            
            maxDiameter = Math.Max(maxDiameter, leftHeight + rightHeight);
            return 1 + Math.Max(leftHeight, rightHeight);   
        } 
        
        DFS(root);
        return maxDiameter;
    }

}