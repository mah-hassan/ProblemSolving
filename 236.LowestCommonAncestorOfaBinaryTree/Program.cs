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

public class Solution 
{
    public TreeNode? LowestCommonAncestor(TreeNode? root, TreeNode p, TreeNode q) 
    {
        if(root is null) return null;

        if(root == p || root == q)  
            return root;
        

        var left = LowestCommonAncestor(root.left, p, q);
        var right = LowestCommonAncestor(root.right, p, q);
        if(left is not null && right is not null) return root;
        if(left is not null) return left;
        if(right is not null) return right;
        return null;
    }
}