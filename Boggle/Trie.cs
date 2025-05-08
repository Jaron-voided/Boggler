using System.Reflection.Metadata;

namespace Boggle;

public class Trie
{
    private readonly TrieNode _root = new TrieNode();


    public void Traverse(char c)
    {
        if (_root.HasChild(c))
        {
            // ????
        }
    }
    
    
    public static Trie CreateBoggleTrie(IEnumerable<string> words)
    {
        // Create a trie containing Boggle Words
        Trie boggleTrie = new Trie();
        foreach (string word in words)
            boggleTrie.Insert(word);
        
        return boggleTrie;
    }

    private void Insert(string word)
    {
        // Start at the root
        var node = _root;
        
        foreach (char c in word)
        {
            // If that node doesn't exist already    
            // It could already exist from a different word
            if (!node.HasChild(c))
            {
                // create it
                node.Children[c] = node.AddChild(c);
            }
            
            // move from root(or current node) to the new node
            // Move to the child node for this letter (create it if it didn’t exist above)
            node = node.Children[c];
        }
        
        // once finishing through the nodes for the word, clarify this is a word
        node.IsWord = true;
    }
    
    
}