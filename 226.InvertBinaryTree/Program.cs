TreeNode root = new(1)
{
    left = new(2),
    right = new(3){
        right = new(4)
    }
};

var solution = new Solution();

TreeNode result = solution.InvertTree(root);

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
    public TreeNode InvertTree(TreeNode root) {
        Queue<TreeNode?> nodes = new();
        nodes.Enqueue(root);
        while(nodes.Count > 0) 
        {
            var node = nodes.Dequeue();
            if(node is not null)
            {
                if(node.left is null && node.right is null)
                    continue;        
                else
                {
                    nodes.Enqueue(node.right);
                    nodes.Enqueue(node.left);
                    SwapChildNodes(node);
                }
            }
        }
        return root;
    }
    private void SwapChildNodes(TreeNode parent)
    {
        TreeNode? temp = parent.left;
        parent.left = parent.right;
        parent.right = temp;
    }
}