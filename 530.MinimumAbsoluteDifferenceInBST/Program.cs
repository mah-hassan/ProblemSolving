
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
    // Use DFS With InOrder Traversal and return abs value of minAbsDiff
    public int GetMinimumDifference(TreeNode root) {
        if(root is null) return 0;  
        Stack<TreeNode> nodes = new();
        List<int> result = new();
        var current = root;
        while(nodes.Count > 0 || current is not null)
        {
            while(current is not null)
            {
                nodes.Push(current);
                current = current.left;
            }
            current = nodes.Pop();
            result.Add(current.val);
            current = current.right;
        }
        int minAbsDiff = int.MaxValue;
        for(int i = 0; i < result.Count - 1; i++)
            minAbsDiff = Math.Min(minAbsDiff, Math.Abs(result[i] - result[i + 1]));
        return minAbsDiff;
    }
}