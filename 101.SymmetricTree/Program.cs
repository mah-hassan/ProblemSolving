
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
    public bool IsSymmetric(TreeNode root) {
        if(root is null) return true;
        Queue<TreeNode?> nodes = new();
        nodes.Enqueue(root);
        while(nodes.Count > 0)
        {
            List<TreeNode?> levelNodes = new();
            int currentCount = nodes.Count;
            for(int i = 0; i < currentCount; i++)
            {
                TreeNode? node = nodes.Dequeue();
                levelNodes.Add(node);
                if(node is not null)
                {
                    nodes.Enqueue(node.left);
                    nodes.Enqueue(node.right);
                }
            }
            for(int i = 0; i < levelNodes.Count / 2; i++)
            {
                if(levelNodes[i]?.val != levelNodes[levelNodes.Count - i - 1]?.val)
                    return false;        
            }
        }
        return true;
    }
}