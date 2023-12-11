namespace AdventOfCode2023.Puzzle.Day7;

[PuzzleInformation(Name ="Camel Cards", Day = 7, Complete = true)]
public class Day7 : PuzzleBase<Day7>
{
    public Day7() : base("input.txt") { }

    public override string Part1() => Lines.Select(x => x.Split(" "))
        .Select(x => (GetPairWildcard(x[0]), int.Parse(x[1]), x[0]))
        .OrderBy(x => x.Item1).ThenBy(x => x.Item3, new CardSort(1))
        .Select((x, i) => (i + 1) * x.Item2).Sum().ToString();

    public override string Part2() => Lines.Select(x => x.Split(" "))
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