string s = "a", t = "ab";

Console.WriteLine(new Solution().IsAnagram(s, t)); // Output: false
public class Solution {
    public bool IsAnagram(string s, string t) {
        Dictionary<char, int> sLettersFrequancy = new();
        foreach (var c in s)
        {
            if (sLettersFrequancy.ContainsKey(c))
            {
                sLettersFrequancy[c]++;
            }
            else
            {
                sLettersFrequancy[c] = 1;
            }
        }
        foreach (var c in t)
        {
            if(!sLettersFrequancy.ContainsKey(c))
                return false;
            else if(sLettersFrequancy[c] == 1)
                sLettersFrequancy.Remove(c);                
            else
                sLettersFrequancy[c]--;
        }
        return sLettersFrequancy.Count == 0;

    }
}