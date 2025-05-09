using System.Text;
using Boggle.Utils;

namespace Boggle;

public class DiceBoard
{
    private static int BoardSize = 4;
    private BoggleDie[,] Board = new BoggleDie[BoardSize, BoardSize];
    private Position CurrentPosition { get; set; } =  new Position(0, 0);
    private bool[,] _visited = new bool[4,4];
    
    private readonly BoggleDice _boggleDice;
    
    internal DiceBoard(BoggleDice boggleDice)
    {
        _boggleDice = boggleDice;
    }

    internal List<string> CheckBoardForWords(Trie trie)
    {
        List<string> results = new List<string>();
        List<char> letters = new List<char>();
        for (var i = 0; i < BoardSize; i++)
        {
            for (var j = 0; j < BoardSize; j++)
            {
                if (CheckSpot(trie,i, j))
                {
                    CurrentPosition = new Position(i, j);
                    _visited[i, j] = true;
                    string letter = Board[CurrentPosition.X, CurrentPosition.Y].SelectedFace;
                    if (letter.ToUpper() == "QU")
                    {
                        // If letters are QU add them seperately
                        letters.Add('Q');
                        letters.Add('U');
                    }
                    else
                    {
                        // If not add the letter
                        letters.Add(Board[CurrentPosition.X, CurrentPosition.Y].SelectedFace[0]);
                    }

                    if (trie.CurrentNode.IsWord)
                    {
                        string word = new string(letters.ToArray());
                        results.Add(word);
                    }
                }
                // I need to clear the word eventually, but I want to keep going
                // so if the next word is Catastrophe, I already have Cat
            }
        }

        return results;
    }

    internal bool CheckSpot(Trie trie, int x = 0, int y = 0)
    {
        // Takes the current board letter, or "Qu" and ensures its a char
        string letter = Board[CurrentPosition.X, CurrentPosition.Y].SelectedFace;
        char c;
        if (letter.ToUpper() == "QU")
            c = 'Q';
        // I'll have to figure out how to handle the QU in another function
        else
            c = letter.ToUpper()[0];
        return trie.CurrentNode.HasChild(c);
        // Starts with root, but checks if the current spot has a child in the trie
    }
    internal void MoveSpot(Direction direction)
    {
        CurrentPosition.Add(direction);
    }
    
    internal static DiceBoard MakeBoard()
    {
        BoggleDice boggleDice = new BoggleDice();
        DiceBoard newBoard =  new DiceBoard(boggleDice);
        boggleDice.CreateDice();
        var random = new Random();
        
        Random rng = new Random();
        for (var i = 0; i < 4; i++)
        {
            for (var j = 0; j < 4; j++)
            {
                var index = random.Next(boggleDice.Dice.Count);
                BoggleDie die = boggleDice.Dice[index];
                die.Roll(rng);
                newBoard.Board[i, j] = die;
                boggleDice.Dice.RemoveAt(index);
            }
        }
        return newBoard;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                sb.Append(Board[i, j].ToString().PadRight(3));
            }

            sb.AppendLine();
        }
        return sb.ToString();
    }
}