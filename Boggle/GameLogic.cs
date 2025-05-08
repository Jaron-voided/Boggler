namespace Boggle;

public class GameLogic
{
    private readonly WordleDictionary _wordleDictionary;
    private readonly DiceBoard _diceBoard;

    public GameLogic(WordleDictionary wordleDictionary, DiceBoard diceBoard)
    {
        _wordleDictionary = wordleDictionary;
        _diceBoard = diceBoard;
    }

    // This will check every direction from a die.Face and check for words in all
    // directions
    /*
    public List<string> WordsWithDie(BoggleDie die, int x_index, int y_index)
    {
        WordleDictionary prunedDictionary = _wordleDictionary.WordsStartingWith(die);
        List<string> words = new List<string>();
        return NotImplementedException;
    }
    */

    // needs to be just CheckDown. This will take a current word in also.
    // This way if I check a direction and its a word, I can take that word and pass it
    // To checkUp/Down/Left/Right and if those make a new word, I can pass that word to
    // all four methods again. When it doesn't produce a word I stop that chain
    /*public bool IsWord(string currentLetters)
    {
        if (_wordleDictionary.Words.Contains(currentLetters))
            return true;
        return false;
    }*/

    
    /*public GameLogic Logic(WordleDictionary wordleDictionary, DiceBoard diceBoard)
    {
        GameLogic gameLogic = new GameLogic();
        _wordleDictionary = wordleDictionary;
        _diceBoard = diceBoard;
        return gameLogic;
    }*/
}