namespace Boggle;

public class TrieNode
{
    internal char Letter { get; set; }
    internal bool IsWord { get; set; }
    internal TrieNode?[] Children { get; set; } = new TrieNode?[26];
    internal static TrieNode CreateNode(char c)
    {
        var node = new TrieNode();
        node.Letter = c;
        node.IsWord = false;

        return node;
    }
    public bool HasChild(char c)
    {
        int index = c - 'A';
        return Children[index] != null;
    }
    public TrieNode AddChild(char c)
    {
        int index = c - 'A';
        if (Children[index] == null)
            Children[index] = CreateNode(c);

        return Children[index];
//        if (Children.All(child => child.Letter != c))
  //          Children[c] = CreateNode(c);
        
    //    return Children[c];
    }
}