using System.Text;

string[] strs = ["str","rts","hi"];

var solution = new Solution();
var groups = solution.GroupAnagramsWithSorting(strs); 

foreach(var group in groups)
{
    Console.WriteLine($"Group: [{string.Join(", ", group)}]");
}

public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) 
    {
        Dictionary<string, List<string>> anagramGroups = new();
        foreach(string str in strs)
        {
            var hashKey = GenerateHashKey(str);
            if(anagramGroups.ContainsKey(hashKey))
                anagramGroups[hashKey].Add(str);
            else
            {
                anagramGroups[hashKey] = new List<string> { str };
            }
        }
        
        return new List<IList<string>>(anagramGroups.Values);;
    }
    private string GenerateHashKey(string str)
    {
        int[] charFrequency = new int[26];

        // Count the frequency of each character in the string
        foreach (char c in str)
        {
            charFrequency[c - 'a']++;
        }
        
        // Build the hash key based on the frequency array
        StringBuilder hashKeyBuilder = new();
        for (int i = 0; i < 26; i++)
        {
            if (charFrequency[i] > 0)
            {
                // Append the character and its frequency
                hashKeyBuilder.Append((char)(i + 'a')).Append(charFrequency[i]);
            }
        }

        return hashKeyBuilder.ToString();
    }
    // Using sorting 
    public IList<IList<string>> GroupAnagramsWithSorting(string[] strs) 
    {
        Dictionary<string, List<string>> anagramGroups = new();
        foreach(string str in strs)
        {
            char[] charArray = str.ToCharArray();
            Array.Sort(charArray);
            var hashKey = new string(charArray);
            if(anagramGroups.ContainsKey(hashKey))
                anagramGroups[hashKey].Add(str);
            else       
                anagramGroups[hashKey] = new List<string> { str };
            
        }
        return new List<IList<string>>(anagramGroups.Values);;
    }
}