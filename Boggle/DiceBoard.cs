using System.Text;
using Boggle.Utils;

namespace Boggle;

public class DiceBoard
{
    private static int BoardSize = 4;
    private BoggleDie[,] Board = new BoggleDie[BoardSize, BoardSize];
    private Position CurrentPosition { get; set; } =  new Position(0, 0);
    private VisitHistory History { get; set; } = new VisitHistory();
    
    private readonly BoggleDice _boggleDice;
    
    internal DiceBoard(BoggleDice boggleDice)
    {
        _boggleDice = boggleDice;
    }

    internal HashSet<string> CheckBoardForWords(Trie trie)
    {
        HashSet<string> results = new HashSet<string>();
        results = IterateBoard(trie);

        return results;
    }

    internal HashSet<string> IterateBoard(Trie trie)
    {
        HashSet<string> results = new HashSet<string>();

        for (var i = 0; i < BoardSize; i++)
        {
            for (var j = 0; j < BoardSize; j++)
            {
                if (CheckSpot(trie,i, j))
                {
                    HashSet<string> newWords = ExplorePath(trie, i, j);
                    results.UnionWith(newWords);
                }
            }
        }

        return results;
    }

    internal HashSet<string> ExplorePath(Trie trie, int i, int j)
    {
        char[] word = new char[16];
        int count = 0;
        HashSet<string> foundWords = new HashSet<string>();
        CurrentPosition = new Position(i, j);
        History.Visit(i, j);
        var directions = Direction.EnumerateDirections(i, j);
        foreach (var direction in directions)
        {
            CurrentPosition.Add(direction);
            if (CheckSpot(trie, CurrentPosition.X, CurrentPosition.Y))
            {
                string letters = Board[i, j].SelectedFace;
                char letter = Tools.QuToQ(letters);
                trie.Traverse(letter);
                Tools.AddLettersToWord(word, letter);
                count++;
                if (trie.CurrentNode.IsWord)
                    foundWords.Add(new string(word));
            }
            ExplorePath(trie, i, j, count, word, foundWords);
        }
        return foundWords;
    }

    internal HashSet<string> ExplorePath(Trie trie, int i, int j, int count, char[] word, HashSet<string> foundWords)
    {
        CurrentPosition = new Position(i, j);
        History.Visit(i, j);
        var directions = Direction.EnumerateDirections(i, j);
        foreach (var direction in directions)
        {
            CurrentPosition.Add(direction);
            if (CheckSpot(trie, CurrentPosition.X, CurrentPosition.Y))
            {
                string letters = Board[i, j].SelectedFace;
                char letter = Tools.QuToQ(letters);
                trie.Traverse(letter);
                Tools.AddLettersToWord(word, letter);
                count++;
                if (trie.CurrentNode.IsWord)
                    foundWords.Add(new string(word));
            }
            ExplorePath(trie, i, j, count, word, foundWords);
        }
        
        return foundWords;
    }   
    
    /*
    internal List<string> ExplorePath(Trie trie, int i, int j)
    {
        CurrentPosition = new Position(i, j);
        _visited[i, j] = true;
        var directions = Direction.EnumerateDirections(i, j, _visited);
        foreach (var direction in directions)
        {
            CurrentPosition.Add(direction);
            if (CheckSpot(trie, CurrentPosition.X, CurrentPosition.Y))
            {
                trie.
            }
        }
    }
    */

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