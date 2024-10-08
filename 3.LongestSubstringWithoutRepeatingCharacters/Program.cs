
string s = "pwwkew";

Solution solution = new Solution();

int maxLength = solution.LengthOfLongestSubstring(s);

Console.WriteLine(maxLength);  // Output: 3

public class Solution {
    public int LengthOfLongestSubstring(string s) {
        int maxLength = 0;
        int left = 0;
        HashSet<char> letters = new();
        for(int i = 0; i < s.Length; i++) 
        {
            while(letters.Contains(s[i]))
            {
                letters.Remove(s[left]);
                left++;  
            }
            letters.Add(s[i]);
            maxLength = Math.Max(maxLength, letters.Count);
        }
        return maxLength;
    }
}