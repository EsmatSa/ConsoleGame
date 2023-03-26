using System.Text;

namespace ConsoleGame;

public class Cell
{
    public string Name { get; set; } = Text.Language.DefaultCellName;
    public string Description { get; set; } = Text.Language.DefaultCellDescription;


    public Dictionary<Directions, int> Neighbors { get; set; } = new()
    {
        {Directions.None,-1 },
        {Directions.Up,-1 },
        {Directions.Down,-1},
        {Directions.Right,-1},
        {Directions.Left,-1},

    };
    public bool Visited { get; set; }
    public CellFortune Fortune { get; set; } = 0;
    /// <summary>
    /// to create a description about the Cell , it's index, visited status, gold or trap and neighbours
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        var sb = new StringBuilder();
        if (Visited)
            sb.Append(string.Format(Text.Language.CellOld, Name));
        else
            sb.Append(string.Format(Text.Language.CellNew, Name));
        var names = Enum.GetNames(typeof(Directions));
        var directions = (from dir in names
                          where Neighbors[(Directions)Enum.Parse(typeof(Directions), dir)] > -1
                          select dir.ToLower())
                         .ToArray();
        if (Fortune == CellFortune.Gold || Fortune == CellFortune.Trap)
            sb.Append(string.Format(Description, Enum.GetName(Fortune)));
        else
        {
            sb.Append(string.Format(Description, Enum.GetName(Fortune)));
            sb.Append(string.Format(Text.Language.AvailableCells, Text.Language.JoinedWordList(directions, Text.Language.And)));
        }
        return sb.ToString();
    }

}
