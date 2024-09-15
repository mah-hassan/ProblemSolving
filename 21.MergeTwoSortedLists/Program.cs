public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        if (list1 == null) return list2;
        if (list2 == null) return list1;

        ListNode temp = new ListNode();
        ListNode current = temp; 

        // Traverse both lists and compare nodes
        while (list1 != null && list2 != null)
        {
            if (list1.val <= list2.val)
            {
                current.next = list1;
                list1 = list1.next;
            }
            else
            {
                current.next = list2;
                list2 = list2.next;
            }
            current = current.next;
        }

        // Attach the remaining nodes from list1 or list2 (if any)
        if (list1 != null)
        {
            current.next = list1;
        }
        else if (list2 != null)
        {
            current.next = list2;
        }

        return temp.next;
    }

}
class Program
{
    public static void Main(string[] args)
    {
        // Create two sorted linked lists: 1 -> 3 -> 5 and 2 -> 4 -> 6
        ListNode list1 = new ListNode(1, new ListNode(3, new ListNode(5)));
        ListNode list2 = new ListNode(2, new ListNode(4, new ListNode(6)));

        Console.WriteLine("List 1:");
        PrintList(list1);
        Console.WriteLine("List 2:");
        PrintList(list2);

        Solution solution = new Solution();
        ListNode mergedList = solution.MergeTwoLists(list1, list2);

        Console.WriteLine("Merged List:");
        PrintList(mergedList);
    }

    // Helper method to print the list
    public static void PrintList(ListNode head)
    {
        while (head != null)
        {
            Console.Write(head.val + " ");
            head = head.next;
        }
        Console.WriteLine();
    }
}