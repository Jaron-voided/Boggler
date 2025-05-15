using System.Text.Json;
using System.Transactions;

namespace Boggle;

public class WordleDictionary
{
    internal List<string> Words = new List<string>();
    
    public static WordleDictionary GetWordleDictionary()
    {
        string filePath = "/home/zeref-dragneel/Desktop/Boggle/Boggle/dictionary.json";
        string fileContent = File.ReadAllText(filePath);

        List<string> wordList = JsonSerializer.Deserialize<List<string>>(fileContent);

        WordleDictionary wordleDictionary = new WordleDictionary
        {
            Words = wordList
                .Where(word => !string.IsNullOrEmpty(word) && word.Length <= 16 && word.Length > 2)
                .Select(word => word.ToUpper())
                .ToList()
                
        };
        
        return wordleDictionary;
    }

    public WordleDictionary WordsStartingWith(BoggleDie die)
    {
        WordleDictionary mainDictionary = GetWordleDictionary();
        WordleDictionary prunedDictionary = new WordleDictionary();
            
        prunedDictionary.Words = mainDictionary.Words    
            .Where(w => w.StartsWith(die.SelectedFace))
            .ToList();
        return prunedDictionary;
    }
    
}