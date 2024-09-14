using System.Text;

var s = "A man, a plan, a canal: Panama";
var isPalindrome = new Solution().IsPalindrome(s);
Console.WriteLine(isPalindrome);
public class Solution
{
    public bool IsPalindrome(string s)
    {
        var cleaned = CleanUpSpecialCharacters(s);
        for (int i = 0; i < cleaned.Length / 2; i++)
        {
            if (cleaned[i] != cleaned[(cleaned.Length - 1) - i])
            {
                return false;
            }
        }
        return true;
    }
    private string CleanUpSpecialCharacters(string s)
    {
        var cleaned = new StringBuilder();
        foreach (char c in s)
        {
            if (char.IsLetterOrDigit(c))
            {
                cleaned.Append(char.ToLowerInvariant(c));
            }      
        }
        return cleaned.ToString();
    }
}