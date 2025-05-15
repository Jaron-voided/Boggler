using System.Reflection.Metadata;

namespace Boggle;

public class Trie
{
    private readonly TrieNode _root = new TrieNode();
    public TrieNode CurrentNode { get; set; }
    
    public void Traverse(char c)
    {
        int index = c - 'A';

        if (CurrentNode.HasChild(c))
        {
            CurrentNode = CurrentNode.Children[index];
            //CurrentNode = CurrentNode.Children[c];
        }
    }
    
    
    public static Trie CreateBoggleTrie(IEnumerable<string> words)
    {
        // Create a trie containing Boggle Words
        Trie boggleTrie = new Trie();
        boggleTrie.CurrentNode = boggleTrie._root;
        foreach (string word in words)
            boggleTrie.Insert(word);
        return boggleTrie;
    }

    private void Insert(string word)
    {
        // Start at the root
        var node = _root;
        word = word.ToUpper();

        foreach (char c in word)
        {
            int index = c - 'A';
            // If that node doesn't exist already    
            // It could already exist from a different word
            if (!node.HasChild(c))
            {
                // create it
                node.AddChild(c);
                //node.Children[c] = node.AddChild(c);
            }
            
            // move from root(or current node) to the new node
            // Move to the child node for this letter (create it if it didn’t exist above)
            
            node = node.Children[index];
            //node = node.Children[c];
        }
        
        // once finishing through the nodes for the word, clarify this is a word
        node.IsWord = true;
    }
    
    
}