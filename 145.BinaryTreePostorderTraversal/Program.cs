
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

    private static List<int> emptyList = new List<int>();
    public IList<int> PostorderTraversal(TreeNode? root) {

        if(root is null) return emptyList;

        var result = new List<int>();

        var leftPath = PostorderTraversal(root.left);
        result.AddRange(leftPath);

        var rightPath = PostorderTraversal(root.right);
        result.AddRange(rightPath);

        result.Add(root.val);
        return result;
    }
    public IList<int> PostorderTraversalIteratively(TreeNode? root)
    {
        if(root is null) return emptyList;
        var result = new List<int>();
        Stack<TreeNode?> nodes = new();
        List<bool> visitedNodes = new();
        nodes.Push(root);
        visitedNodes.Add(false);
        while(nodes.Count > 0)
        {
            var (curr, visited) = (nodes.Pop(), visitedNodes[^1]);
            if(curr is not null)
            {
                if(visited)
                {
                    visitedNodes.RemoveAt(visitedNodes.Count - 1);  
                    result.Add(curr.val);
                }
                else
                {
                    nodes.Push(curr);
                    visitedNodes[^1] = true;
                    nodes.Push(curr.right);
                    visitedNodes.Add(false);
                    nodes.Push(curr.left);
                    visitedNodes.Add(false);
                }
            }
            else
            {
                visitedNodes.RemoveAt(visitedNodes.Count - 1);
            }

        }
        return result;
    }
}