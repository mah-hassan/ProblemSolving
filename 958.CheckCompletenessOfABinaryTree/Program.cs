
public class TreeNode {
    public int val;
    public TreeNode? left;
    public TreeNode? right;
    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
 
public class Solution {
    public bool IsCompleteTree(TreeNode root) {
        if(root is null) return false;
        
        Queue<TreeNode> nodes = new();
        nodes.Enqueue(root);
        bool foundNullNode = false;
        while(nodes.Count > 0)
        {
            var node = nodes.Dequeue();
            if(node.left is not null)
            {
                if(foundNullNode) return false;
                nodes.Enqueue(node.left);
            }
            else foundNullNode = true;

            if(node.right is not null)
            {
                if(foundNullNode) return false;
                nodes.Enqueue(node.right);
            }
            else foundNullNode = true;
            // in last level if all the right node is null no problem as we finch the loop and return true
        }
        return true;
    }
}