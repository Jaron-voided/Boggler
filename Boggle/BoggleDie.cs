namespace Boggle;

public struct BoggleDie
{
    internal string[] Faces { get; set; }
    public string SelectedFace { get; private set; }
    
    public BoggleDie() { }

    public void Roll(Random rng)
    {
        SelectedFace = Faces[rng.Next(0, Faces.Length)];
    }
    
    internal static BoggleDie CreateDie(string[] faces)
    {
        BoggleDie die = new BoggleDie();
        die.Faces = faces;
        return die;
    }

    public override string ToString()
    {
        return SelectedFace.ToString() ?? "?";
    }
}