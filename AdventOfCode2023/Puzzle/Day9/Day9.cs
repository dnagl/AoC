namespace AdventOfCode2023.Puzzle.Day9;

[PuzzleInformation(Name ="Mirage Maintenance", Day = 7, Complete = true)]
public class Day9 : PuzzleBase<Day9>
{

    private long _resultPart1 = 0;
    private long _resultPart2 = 0;
    
    public Day9() : base("input.txt") { }

    public override string Part1()
    {
        Solve();
        return _resultPart1.ToString();
    }

    public override string Part2()
    {
        Solve();
        return _resultPart2.ToString();
    }
    
    private void Solve()
    {
        var lines = Lines.Select(x => x.Split(" ").Select(long.Parse).ToArray()).ToList();
    
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

            var valuePart1 = 0L;
            var valuePart2 = 0L;
        
            foreach (var reduction in currentReduction.Skip(1))
            {
                valuePart1 += reduction.Last();
                valuePart2 = reduction.First() - valuePart2;
            }

            _resultPart1 += valuePart1;
            _resultPart2 += valuePart2;
        }
    }
}