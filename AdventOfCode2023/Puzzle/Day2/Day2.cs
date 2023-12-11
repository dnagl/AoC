namespace AdventOfCode2023.Puzzle.Day2;

[PuzzleInformation(Name ="Cube Condrum", Day = 2, Complete = true)]
public class Day2 : PuzzleBase<Day2>
{
    public Day2() : base("input.txt") { }

    public override string Part1()
    {
        return Parse()
            .Where(game => game.Drafts.All(draft => draft is { Red: <= 12, Green: <= 13, Blue: <= 14 }))
            .Select(game => game.Id)
            .Sum().ToString();
    }

    public override  string Part2()
    {
        return Parse()
            .Select(game => game.GetMinimumCubeSet())
            .Select(x => x.Blue * x.Green * x.Red)
            .Sum().ToString();
    }

    private IEnumerable<Game> Parse() => Utils.Utils.ReadPuzzleLines(2, Filename).Select(Game.Parse);
}