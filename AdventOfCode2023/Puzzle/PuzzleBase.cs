namespace AdventOfCode2023.Puzzle;

public abstract class PuzzleBase<T> : IPuzzle
    where T : class
{
    protected IEnumerable<string> Lines;
    protected string Filename;

    protected PuzzleBase(string filename)
    {
        Filename = filename;
        var attribute = Attribute.GetCustomAttribute(typeof(T), typeof(PuzzleInformation)) as PuzzleInformation;
        if (attribute == null) throw new Exception("PuzzleInformation attribute is missing");
        Lines = Utils.Utils.ReadPuzzleLines(attribute.Day, Filename);
    }

    public virtual void Setup(){}
    public abstract string Part1();
    public abstract string Part2();
}