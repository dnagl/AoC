namespace AdventOfCode2023.Puzzle.Day7;

[PuzzleInformation(Name ="Camel Cards", Day = 7, Complete = true)]
public class Day7 : IPuzzle
{
    private const string Filename = "input.txt";
    private IEnumerable<string> _lines;
    
    public void Setup()
    {
        _lines = Utils.Utils.ReadPuzzleLines(7, Filename);
    }

    public string Part1() => _lines.Select(x => x.Split(" "))
        .Select(x => (GetPairWildcard(x[0]), int.Parse(x[1]), x[0]))
        .OrderBy(x => x.Item1).ThenBy(x => x.Item3, new CardSort(1))
        .Select((x, i) => (i + 1) * x.Item2).Sum().ToString();

    public string Part2() => _lines.Select(x => x.Split(" "))
        .Select(x => (GetPairWildcard(x[0]), int.Parse(x[1]), x[0]))
        .OrderBy(x => x.Item1).ThenBy(x => x.Item3, new CardSort(1))
        .Select((x, i) => (i + 1) * x.Item2).Sum().ToString();
    
    private int GetPairType(string s)
    {
        var group = s.GroupBy(x => x).ToArray();
        return (group.Length, group.Max(x => x.Count())) switch
        {
            (5,1) => 0,
            (4,2) => 1,
            (3,2) => 2,
            (3,3) => 3,
            (2,3) => 4,
            (2,4) => 5,
            (1,6) => 6,
            _ => -1
        };
    }

    private int GetPairWildcard(string s) => !s.Contains('J')
        ? GetPairType(s)
        : s.Replace("J", "").Distinct()
            .Select(c => GetPairType(s.Replace('J', c)))
            .Prepend(GetPairType(s)).Max();
}