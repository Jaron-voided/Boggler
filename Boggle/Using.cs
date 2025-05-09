namespace Boggle;

public class Using
{
    public void Run()
    {
        DiceBoard board = DiceBoard.MakeBoard();
        // Creates a board with random dice
        
        board.CheckBoardForWords();
        // this will start at 0,0 and run CheckSpot in a loop to check all spots
        // CheckSpot will verify the letter is a child of root(it is)
        // then run checks over the IEnumerable directions
        // it will go all the way down the first direction
        // each subsequent check will check down first, DFS
        // 
        
        
    }


}