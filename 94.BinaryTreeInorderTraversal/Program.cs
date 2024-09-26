
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
    private static List<int> emptyList = new();
    // Iteratively
    public IList<int> InorderTraversal(TreeNode? root)
    {
        if(root is null) return emptyList;
        var result = new List<int>();
        Stack<TreeNode> nodes = new();
  

        var curr = root;
        while(nodes.Count > 0 || curr is not null)
        {
           
            while(curr is not null)
            {   
                nodes.Push(curr);
                curr = curr.left; 
            } 
            curr = nodes.Pop();

            result.Add(curr.val);

            curr = curr.right;  
        }
        return result;
    }




    // Recursively
    // public IList<int> InorderTraversal(TreeNode? root)
    // {
    //     if(root is null) return emptyList;
    //     var result = new List<int>();
    //     result.AddRange(InorderTraversal(root.left));
    //     result.Add(root.val);
    //     result.AddRange(InorderTraversal(root.right));
    //     return result;
    // }
}