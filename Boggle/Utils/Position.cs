namespace Boggle.Utils;

public readonly struct Position(int x, int y)
{
    internal int X { get; } = x;
    internal int Y { get; } = y;

    public Position Add(Direction direction)
        => new(X + direction.DX, Y + direction.DY);
}