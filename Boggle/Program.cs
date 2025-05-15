// See https://aka.ms/new-console-template for more information

using Boggle;

DiceBoard board = DiceBoard.MakeBoard();
// Creates a board with random dice
WordleDictionary dict = WordleDictionary.GetWordleDictionary();
Trie trie = Trie.CreateBoggleTrie(dict.Words);
HashSet<string> playableWords = board.CheckBoardForWords(trie);

foreach (string word in playableWords)
{
    Console.WriteLine(word);
}

