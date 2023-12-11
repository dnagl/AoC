namespace AdventOfCode2023.Puzzle;

public abstract class PuzzleBase<T> : IPuzzle
    where T : class
{
    protected IEnumerable<string> Lines;
    protected string Filename;

    protected PuzzleBase(string filename)
    {
        Filename = filename;
    }

    public virtual void Setup()
    {
        var attribute = Attribute.GetCustomAttribute(typeof(T), typeof(PuzzleInformation)) as PuzzleInformation;
        Lines = Utils.Utils.ReadPuzzleLines(attribute.Day, Filename);
    }

    public abstract string Part1();
    public abstract string Part2();
}