namespace HauntedWasteland;

public class Map
{
    public List<char> Directions { get; set; } = new();
    public Dictionary<string, Tuple<string, string>> Nodes { get; set; } = new();

    public static Map Parse(IEnumerable<string> input)
    {
        var map = new Map();
        var isDirections = true;
        foreach (var line in input)
        {
            if (line.Trim().Length == 0)
            {
                isDirections = false;
                continue;
            }

            if (isDirections)
                map.Directions = line.Select(x => x).ToList();
            else
                map.Nodes.Add(line.Split("=").First().Trim(), ParseTuple(line));
        }

        return map;
    }

    private static Tuple<string, string> ParseTuple(string input)
    {
        var parts = input
            .Split("=").Last()
            .Replace("(", "")
            .Replace(")", "")
            .Split(",").Select(x => x.Trim());
        return new Tuple<string, string>(parts.First(), parts.Last());
    } 
}