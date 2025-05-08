namespace Boggle;

public class TrieNode
{
    public bool IsWord { get; set; }
    
    // All the letters/nodes past this node
    public Dictionary<char, TrieNode> Children { get; set; }

    public bool HasChild(char c)
    {
        return Children.ContainsKey(c);
    }

    public TrieNode AddChild(char c)
    {
        if (!Children.ContainsKey(c))
            Children[c] = new TrieNode();
        
        return Children[c];
    }
}