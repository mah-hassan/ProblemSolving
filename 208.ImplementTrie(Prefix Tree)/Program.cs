
using System.Numerics;
Trie trie = new Trie();

trie.Insert("apple");
trie.Insert("app");


bool search = trie.Search("apple"); // returns true

bool startsWith = trie.StartsWith("app"); // returns true



public class Trie {

    public Trie() 
    {
        
    }
    private Dictionary<char, Node> Nodes = new();
   
    public void Insert(string word) 
    {
        
        if(!Nodes.ContainsKey(word[0]))
        {   
            Nodes[word[0]] = new Node(word[0]);
        }
       
        var child = Nodes[word[0]];
     
        foreach(char c in word.AsSpan(1))
        { 
            if(!child.Childrens.ContainsKey(c))
            {
                child.AddChild(new Node(c));
            }
            child = child.Childrens[c];
        }
        child.IsEndOfWord = true;
    }
    
    public bool Search(string word) {
        if(!Nodes.ContainsKey(word[0])) return false;
        var child = Nodes[word[0]];
        foreach(char c in word.AsSpan(1))
        {
            if(!child.Childrens.ContainsKey(c)) return false;
            child = child.Childrens[c];
        }
        return child.IsEndOfWord;
    }
    
    public bool StartsWith(string prefix) {
        if(!Nodes.ContainsKey(prefix[0])) return false;
        var child = Nodes[prefix[0]];
        foreach(char c in prefix.AsSpan(1))
        {
            if(!child.Childrens.ContainsKey(c)) return false;
            child = child.Childrens[c];
        }
        return true;
    }
    private record Node
    {
        public char Value { get; set; }
        public bool IsEndOfWord { get; set; }
        public Dictionary<char, Node> Childrens { get; set; } = new();
        
        public Node(char value)
        {
            Value = value;
        }
        public void AddChild(Node child)
        {
            if(!Childrens.ContainsKey(child.Value)) 
                Childrens[child.Value] = child;
        }
    }
}