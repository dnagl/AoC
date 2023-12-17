namespace AdventOfCode2023.Puzzle;

[AttributeUsage(AttributeTargets.Class)]
public class PuzzleInformation : Attribute
{
    public required string Name { get; set; }
    public required int Day { get; set; }
    public required bool Complete { get; set; }
}