
public class ListNode {
    public int val;
    public ListNode? next;
    public ListNode(int val = 0, ListNode? next = null) {
        this.val = val;
        this.next = next;
    }
}

public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        if(l1 is null && l2 is not null) return l2;
        else if(l1 is not null && l2 is null) return l1;
        else if(l1 is null && l2 is null) return new (0);

        ListNode result = new (0);
        ListNode current = result;
        int carry = 0;
        while(l1 is not null || l2 is not null || carry > 0)
        {
            int sum = carry;
            if(l1 is not null) {
                sum += l1.val;
                l1 = l1.next!;
            }
            if(l2 is not null) {
                sum += l2.val;
                l2 = l2.next!;
            }
            carry = sum / 10;
            current.next = new ListNode(sum % 10);
            current = current.next;
        }
        return result.next!;
    }
}