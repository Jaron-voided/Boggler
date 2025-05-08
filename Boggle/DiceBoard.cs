using System.Text;
using Boggle.Utils;

namespace Boggle;

public class DiceBoard
{
    internal BoggleDie[,] Board = new BoggleDie[4, 4];
    
    internal Position CurrentPosition { get; set; } =  new Position(0, 0);
    
    private readonly BoggleDice _boggleDice;
    
    
    internal DiceBoard(BoggleDice boggleDice)
    {
        _boggleDice = boggleDice;
    }

    internal void MoveSpot(Direction direction)
    {
        CurrentPosition.Add(direction);
    }
    
    internal DiceBoard MakeBoard()
    {
        DiceBoard newBoard =  new DiceBoard(_boggleDice);
        _boggleDice.CreateDice();
        var random = new Random();
        
        Random rng = new Random();
        for (var i = 0; i < 4; i++)
        {
            for (var j = 0; j < 4; j++)
            {
                var index = random.Next(_boggleDice.Dice.Count);
                BoggleDie die = _boggleDice.Dice[index];
                die.Roll(rng);
                Board[i, j] = die;
                _boggleDice.Dice.RemoveAt(index);
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