

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
    public int KthSmallest(TreeNode root, int k) {
        Stack<TreeNode> nodes = new();
        int kth = 0; // do InOrder DFS traversal until kth is equal to k which is the target
        var current = root;
        while(nodes.Count > 0 || current is not null)
        {
            while(current is not null)
            {
                nodes.Push(current);
                current = current.left;
            }
            current = nodes.Pop();
            kth++;
            if(kth == k)
                return current.val; 
            current = current.right;
        }
        return -1;
    }
}