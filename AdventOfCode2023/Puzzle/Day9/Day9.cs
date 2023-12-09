namespace AdventOfCode2023.Puzzle.Day9;

[PuzzleInformation(Name ="Mirage Maintenance", Day = 7, Complete = true)]
public class Day9 : IPuzzle
{
    private readonly string _filename = "input.txt";
    private IEnumerable<string> _lines;

    private long _resultPart1 = 0;
    private long _resultPart2 = 0;
    
    public void Setup()
    {
        _lines = Utils.Utils.ReadPuzzleLines(9, _filename);
        Run();
    }

    private void Run()
    {
        var lines = _lines.Select(x => x.Split(" ").Select(long.Parse).ToArray()).ToList();
    
        foreach (var line in lines)
        {
            var currentReduction = new List<List<long>>();
            currentReduction.Add(line.ToList());

            while (currentReduction.Last().Any(x => x != 0))
            {
                var current = currentReduction.Last();
                List<long> nextReduction = new(current.Count - 1);
                for(var i = 1; i < current.Count; i++)
                    nextReduction.Add(current[i] - current[i - 1]);
                currentReduction.Add(nextReduction);
            }

            currentReduction.Reverse();

            var valuePart1 = 0l;
            var valuePart2 = 0l;
        
            foreach (var reduction in currentReduction.Skip(1))
            {
                valuePart1 += reduction.Last();
                valuePart2 = reduction.First() - valuePart2;
            }

            _resultPart1 += valuePart1;
            _resultPart2 += valuePart2;
        }
    }

    public string Part1() => _resultPart1.ToString();

    public string Part2() => _resultPart2.ToString();
}