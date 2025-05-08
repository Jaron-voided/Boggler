namespace Boggle;

public class Direction
{
    public int DX { get; }
    public int DY { get; }
    private Direction(int dx, int dy)
    {
        DX = dx;
        DY = dy;
    }

    private static readonly Direction Up = new(0, -1);
    private static readonly Direction Down = new(0, 1);
    private static readonly Direction Left = new(-1, 0);
    private static readonly Direction Right = new(1, 0);

    private static readonly Direction UpLeft = new(-1, -1);
    private static readonly Direction UpRight = new(1, -1);
    private static readonly Direction DownLeft = new(-1, 1);
    private static readonly Direction DownRight = new(1, 1);
    
    public static readonly Direction[] All = {
        Up, Down, Left, Right,
        UpLeft, UpRight, DownLeft, DownRight
    };
    
    internal IEnumerable<Direction> GetPossibleDirections(int x, int y)
    {
        List<Direction> directions = Direction.All.ToList();

        switch (x)
        {
            case 0:
                directions.RemoveAll(d =>
                    d == Direction.Left ||
                    d == Direction.DownLeft ||
                    d == Direction.UpLeft
                );
                break;
            case 3:
                directions.RemoveAll(d =>
                    d == Direction.Right ||
                    d == Direction.DownRight ||
                    d == Direction.UpRight
                );
                break;
        }

        switch (y)
        {
            case 0:
                directions.RemoveAll(d =>
                    d == Direction.Up ||
                    d == Direction.UpRight ||
                    d == Direction.UpLeft
                );
                break;
            case 3:
                directions.RemoveAll(d =>
                    d == Direction.Down ||
                    d == Direction.DownRight ||
                    d == Direction.DownLeft
                );
                break;
        }

        return directions.AsEnumerable();
    }

}