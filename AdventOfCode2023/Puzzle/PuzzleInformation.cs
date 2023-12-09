namespace AdventOfCode2023.Puzzle;

[AttributeUsage(AttributeTargets.Class)]
public class PuzzleInformation : Attribute
{
    public string Name { get; set; }
    public int Day { get; set; }
    public bool Complete { get; set; }
}