

namespace ConsoleGame;

public partial class Board
{
    public Player Player { get; }
    private readonly Random _rnd = new Random(3654); 

    public int Width { get; set; }
    public int Height { get; set; }
    public int Size => Width * Height ;
    public Space[] Spaces { get; private set; }

    public Board(Player player)
    {
        Player = player;
    }


}