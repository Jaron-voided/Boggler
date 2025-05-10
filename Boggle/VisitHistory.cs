namespace Boggle;

public struct VisitHistory
{
    private const int BoardSize = 4;
    private int _history; // bitmask to track visited positions

    public void Visit(int x, int y)
    {
        // Convert 2D board coordinates into a linear index(0-15)
        // Maps the tile to unique bit position
        int index = y * BoardSize + x; 
        
        // Bitwise OR assignment, sets bit at index to 1
        // 1 << index moves a 1 to the appropriate bit position
        // |= updates history to reflect the visit without touching other bits
        _history |= (1 << index);
    }

    // Check if tile has already been visited
    public bool IsVisited(int x, int y)
    {
        // Linearizes the 2D x,y coordinate
        int index = y * BoardSize + x;
        
        // Bitwise AND: checks if the bit at index is set
        // Returns true fi its visited(1) false if not (0)
        return (_history & (1 << index)) != 0;
    }
}