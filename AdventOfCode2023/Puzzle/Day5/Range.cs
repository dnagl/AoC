namespace AdventOfCode2023.Puzzle.Day5;

public class Range
{
    public long DestinationStart { get; set; }
    public long SourceStart { get; set; }
    public long Length { get; set; }
    
    public static Range Parse(string s)
    {
        return new Range
        {
            DestinationStart = long.Parse(s.Split(" ")[0]),
            SourceStart = long.Parse(s.Split(" ")[1]),
            Length = long.Parse(s.Split(" ")[2]),
        };
    }
}