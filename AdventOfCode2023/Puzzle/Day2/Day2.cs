namespace AdventOfCode2023.Puzzle.Day2;

[PuzzleInformation(Name ="Cube Condrum", Day = 2, Complete = true)]
public class Day2 : IPuzzle
{
    private readonly string _filename = "input.txt";
    private IEnumerable<string> _lines;
    
    public void Setup()
    {
        _lines = Utils.Utils.ReadPuzzleLines(2, _filename);
    }

    public string Part1()
    {
        return Parse()
            .Where(game => game.Drafts.All(draft => draft is { Red: <= 12, Green: <= 13, Blue: <= 14 }))
            .Select(game => game.Id)
            .Sum().ToString();
    }

    public string Part2()
    {
        return Parse()
            .Select(game => game.GetMinimumCubeSet())
            .Select(x => x.Blue * x.Green * x.Red)
            .Sum().ToString();
    }

    private IEnumerable<Game> Parse() => Utils.Utils.ReadPuzzleLines(2, _filename).Select(Game.Parse);
}