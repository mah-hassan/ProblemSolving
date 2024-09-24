TreeNode root = new TreeNode(0) 
{
    left = new TreeNode(2) 
    {
        left = new TreeNode(1) 
        {
            left = new TreeNode(5),
            right = new TreeNode(1)
        }
    },
    right = new TreeNode(4) 
    {
        left = new TreeNode(3) 
        {
            right = new TreeNode(6)
        },
        right = new TreeNode(-1) 
        {
            right = new TreeNode(8)
        }
    }
};
//           0
//      2        4
//    1      3      -1
//  5   1      6       8
var solution = new Solution();

int result = solution.MaxDepth(root);


Console.WriteLine(result);  

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
    // public int MaxDepth(TreeNode root) {
    //     int depth = 0;
    //     if (root != null) {
    //         int leftDepth = MaxDepth(root.left);
    //         int rightDepth = MaxDepth(root.right);
    //         depth = Math.Max(leftDepth, rightDepth) + 1;
    //     }
    //     return depth;
    // }



    // Using Iterative DFS
    public int MaxDepth(TreeNode root) 
    {
        if (root is null) return 0;
        Stack<(TreeNode node, int depth)> nodes = new();
        nodes.Push((root, 1)); 
        int maxDepth = 1;

        while(nodes.Count > 0)
        {
            (TreeNode node, int depth) = nodes.Pop(); 
            maxDepth = Math.Max(maxDepth, depth);
            if(node.left is not null) nodes.Push((node.left, depth + 1)); 
            if(node.right is not null) nodes.Push((node.right, depth + 1));           
        }
        return maxDepth;
    }

    // Using Iterative BFS
    // public int MaxDepth(TreeNode root) 
    // {
    //     if (root is null) return 0;
    //     Queue<TreeNode> nodes = new(); // 0
    //     nodes.Enqueue(root); 
    //     int maxDepth = 0; // 0
    //     while(nodes.Count > 0)
    //     {
    //         int currCount = nodes.Count;
    //         for(int i = 0; i < currCount; i++)
    //         {
    //             var node = nodes.Dequeue();
    //             if(node.left is not null) nodes.Enqueue(node.left); 
    //             if(node.right is not null) nodes.Enqueue(node.right); 
    //         }
    //         maxDepth++;
    //     }
    //     return maxDepth;
    // }
}