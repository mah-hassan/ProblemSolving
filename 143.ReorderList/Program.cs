
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null) {
        this.val = val;
        this.next = next;
    }
}
// My Solution much straightforward and easy to understand but memory inefficient with soace complexity O(n) for stack allocation
// Good for small lists
public class Solution
{
    public void ReorderList(ListNode head)
    {
        if (head == null || head.next == null)
            return;

        // Example: 1 -> 2 -> 3 -> 4
        var reversedList = new Stack<ListNode>();
        var current = head;
        int length = 0;

        // Step 1: Count the total number of nodes and push all to the stack
        // reversedList: 4 -> 3 -> 2 -> 1 (Top of stack is 4)
        while (current != null)
        {
            reversedList.Push(current);  // Push nodes to stack in order: 1, 2, 3, 4
            current = current.next;
            length++;  // length becomes 4
        }

        // Step 2: Reorder the list
        current = head; // current = 1 (head of the original list)
        for (int i = 0; i < length / 2; i++)
        {
            // On the first iteration, i = 0, current = 1, reversedList = [4, 3, 2]
            var nodeFromEnd = reversedList.Pop();  // nodeFromEnd = 4 (popped from stack)
            var next = current.next;  // next = 2 (save the next node in the original list)

            // Re-link nodes: 
            // current = 1 -> nodeFromEnd = 4 -> next = 2
            current.next = nodeFromEnd;  // 1 -> 4
            nodeFromEnd.next = next;     // 4 -> 2

            // Move to the next original node
            current = next;  // current = 2

            // After the first iteration, the list is: 1 -> 4 -> 2 -> 3
        }

        // Step 3: Set the next of the last node to null to terminate the list
        // After completing the loop, current = 2 -> 3, we need to terminate at 2 -> 3
        current.next = null;  // Final list: 1 -> 4 -> 2 -> 3 -> null
    }
}

// Chatgpt Solution more complicated but memory efficient with soace complexity O(1)
//public class Solution
//{
//    public void ReorderList(ListNode head)
//    {
//        if (head == null || head.next == null)
//            return;

//        // Step 1: Find the middle of the list
//        ListNode slow = head, fast = head;
//        while (fast != null && fast.next != null)
//        {
//            slow = slow.next;
//            fast = fast.next.next;
//        }

//        // Step 2: Reverse the second half of the list
//        ListNode prev = null, curr = slow, next = null;
//        while (curr != null)
//        {
//            next = curr.next;
//            curr.next = prev;
//            prev = curr;
//            curr = next;
//        }

//        // Step 3: Merge the two halves
//        ListNode first = head, second = prev;
//        while (second.next != null)
//        {
//            ListNode temp1 = first.next, temp2 = second.next;
//            first.next = second;
//            second.next = temp1;
//            first = temp1;
//            second = temp2;
//        }
//    }
//}
