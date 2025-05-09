namespace Boggle;

public class BoggleDice
{
    internal List<BoggleDie> Dice { get; set; } = new List<BoggleDie>();
    
    public BoggleDice()
    {
    }

    internal BoggleDice CreateDice()
    {
        BoggleDice dice = new BoggleDice();
        //var index = 0;
        foreach (string[] face in DiceFaces.BoggleDiceFaces)
        {
            BoggleDie die = BoggleDie.CreateDie(face);
            Dice.Add(die);
        }

        return dice;
    }
}