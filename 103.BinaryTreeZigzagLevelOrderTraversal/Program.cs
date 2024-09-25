
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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        List<IList<int>> result = new();
        if(root is null) return result;
        Queue<TreeNode> nodes = new();
        nodes.Enqueue(root);

        bool leftToRight = true;
        while(nodes.Count > 0)
        {
            List<int> level = new();
            
            int currCount = nodes.Count;

            for(int i = 0; i < currCount; i++)
            {
                var node = nodes.Dequeue();
                level.Add(node.val);

                if(node.left is not null) nodes.Enqueue(node.left);
                if(node.right is not null) nodes.Enqueue(node.right);
            }
            if(!leftToRight) level.Reverse();
            result.Add(level);
            leftToRight = !leftToRight;
        }

        return result;
    }
}