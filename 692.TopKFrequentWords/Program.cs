string[] words = ["the","day","is","sunny","the","the","the","sunny","is","is"];
// string[] words = ["i","love","leetcode","i","love","coding"];

int k = 4;

var solution = new Solution();

var topKFrequentWords = solution.TopKFrequent(words, k);

Console.WriteLine($"Top {k} frequent words are: {string.Join(", ", topKFrequentWords)}");

public class Solution {
    public IList<string> TopKFrequent(string[] words, int k) {
        Dictionary<string, int> frequencies = new();
        foreach (string word in words)
        {
            if (frequencies.ContainsKey(word)) frequencies[word]++;
            else frequencies[word] = 1;
        }
        PriorityQueue<string, (int, string)> priorityQueue = new(new WordsComparer());
        foreach (var freq in frequencies)
        {
            priorityQueue.Enqueue(freq.Key, (freq.Value, freq.Key));
        }
        List<string> result = new();
        for (int i = 0; i < k; i++)
        {
            result.Add(priorityQueue.Dequeue());
        }
        return result;
    }
    public class WordsComparer : IComparer<(int freq, string word)>
    {
        public int Compare((int freq, string word) x, (int freq, string word) y)
        {
            if(x.freq == y.freq) return string.Compare(x.word, y.word);
            return y.freq - x.freq;
        }
    }
}