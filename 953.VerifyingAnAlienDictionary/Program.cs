string[] words = ["hello","leetcode"];
string order = "hlabcdefgijkmnopqrstuvwxyz";

var solution = new Solution();

bool isAlienSorted = solution.IsAlienSorted(words, order);

Console.WriteLine(isAlienSorted); 

public class Solution {
    public bool IsAlienSorted(string[] words, string order) 
    {
        Dictionary<char, int> lettersOrder = new();
        for (int i = 0; i < order.Length; i++)
        {
            lettersOrder[order[i]] = i;
        }
        for(int i = 0; i < words.Length - 1; i++)
        {
            (string w1 , string w2) = (words[i], words[i + 1]);
            for(int j = 0; j < w1.Length; j++)
            {
                if(j >= w2.Length || lettersOrder[w1[j]] > lettersOrder[w2[j]])
                {
                    return false;
                }
                else if(lettersOrder[w1[j]] < lettersOrder[w2[j]])
                {
                    break;
                }
            }
        }
        return true;
    }
}