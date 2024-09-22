int[] arr = [1,2];

Solution solution = new Solution();

bool uniqueOccurrences = solution.UniqueOccurrences(arr);

Console.WriteLine(uniqueOccurrences); 

public class Solution {
    public bool UniqueOccurrences(int[] arr) 
    {
        Dictionary<int, int> frequencies = new();
         
        foreach (var num in arr)
        {
            if (frequencies.ContainsKey(num))
                frequencies[num]++;
            else
                frequencies[num] = 1;
        }

        
        HashSet<int> uniqueOccurrences = new();
        
        foreach (var freq in frequencies.Values)
        {
            if (!uniqueOccurrences.Add(freq)) // If freq already exists, return false
                return false;
        }

        return true;
    }
}