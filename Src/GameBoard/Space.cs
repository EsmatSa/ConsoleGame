using System.Text;

namespace ConsoleGame;

public class Space
{
    public string Name { get; set; } = Text.Language.DefaultSpaceName;
    public string Description { get; set; } = Text.Language.DefaultSpaceDescription;


    public Dictionary<Directions, int> Neighbors { get; set; } = new()
    {
        {Directions.None,-1 },
        {Directions.North,-1 },
        {Directions.South,-1},
        {Directions.East,-1},
        {Directions.West,-1},

    };
    public bool Visited { get; set; }
    public SpaceFortune Fortune { get; set; } = 0;
    /// <summary>
    /// to careate a description about the space , it's index, visited status, gold or trap and neighbours
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        var sb = new StringBuilder();
        if (Visited)
            sb.Append(string.Format(Text.Language.SpaceOld, Name));
        else
            sb.Append(string.Format(Text.Language.SpaceNew, Name));
        var names = Enum.GetNames(typeof(Directions));
        var directions = (from dir in names
                          where Neighbors[(Directions)Enum.Parse(typeof(Directions), dir)] > -1
                          select dir.ToLower())
                         .ToArray();
        if (Fortune == SpaceFortune.Gold || Fortune == SpaceFortune.Trap)
            sb.Append(string.Format(Description, Enum.GetName(Fortune)));
        else
        {
            sb.Append(string.Format(Description, Enum.GetName(Fortune)));
            sb.Append(string.Format(Text.Language.AvailableSpaces, Text.Language.JoinedWordList(directions, Text.Language.And)));
        }
        return sb.ToString();
    }

}
