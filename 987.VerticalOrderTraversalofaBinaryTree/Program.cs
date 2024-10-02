
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
    public IList<IList<int>> VerticalTraversal(TreeNode root) {
        var result = new List<IList<int>>();
        if (root is null) return result;

        var columnMap = new SortedDictionary<int, List<(int row, int val)>>();

        Queue<(TreeNode node, int row, int col)> nodes = new();
        nodes.Enqueue((root, 0, 0));

        while (nodes.Count > 0) {
            var (node, row, col) = nodes.Dequeue();

            if (!columnMap.ContainsKey(col)) {
                columnMap[col] = new List<(int, int)>();
            }

            columnMap[col].Add((row, node.val));

            if (node.left != null) 
                nodes.Enqueue((node.left, row + 1, col - 1));
            
            if (node.right != null) 
                nodes.Enqueue((node.right, row + 1, col + 1));
            
        }

        foreach (var col in columnMap) {
            var sortedList = col.Value.OrderBy(x => x.row).ThenBy(x => x.val).Select(x => x.val).ToList();
            result.Add(sortedList);
        }

        return result;
    }
}