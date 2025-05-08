using System.Transactions;

namespace Boggle;

public class WordleDictionary
{
    internal HashSet<string> Words = new HashSet<string>();
    
    public WordleDictionary GetWordleDictionary()
    {
        WordleDictionary wordleDictionary = new WordleDictionary();
        
        string filePath = "dictionary.json";
        
        string fileContent = File.ReadAllText(filePath);

        HashSet<string> wordList = fileContent.Split(',')
            .Select(word => word.Replace("\"", "").Trim())
            .Where(word => !string.IsNullOrEmpty(word) && word.Length <= 16)
            .Distinct()
            .ToHashSet();

        wordleDictionary.Words = wordList;
        return wordleDictionary;
    }

    public WordleDictionary WordsStartingWith(BoggleDie die)
    {
        WordleDictionary mainDictionary = GetWordleDictionary();
        WordleDictionary prunedDictionary = new WordleDictionary();
            
        prunedDictionary.Words = mainDictionary.Words    
            .Where(w => w.StartsWith(die.SelectedFace))
            .ToHashSet();
        return prunedDictionary;
    }
    
}