namespace Boggle.Utils;

public readonly struct Position
{
    public int X { get; }
    public int Y { get; }

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Position Add(Direction direction)
        => new(X + direction.DX, Y + direction.DY);

    public override string ToString() => $"({X}, {Y})";
}