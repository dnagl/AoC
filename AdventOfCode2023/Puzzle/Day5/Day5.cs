namespace AdventOfCode2023.Puzzle.Day5;

[PuzzleInformation(Name ="If You Give A Seed A Fertilizer", Day = 5, Complete = true)]
public class Day5 : IPuzzle
{
    private readonly string _filename = "input.txt";
    private IEnumerable<string> _lines;
    
    public void Setup()
    {
        _lines = Utils.Utils.ReadPuzzleLines(5, _filename);
    }

    public string Part1()
    {
        var input = _lines.ToList();
        var maps = ConvertMap.ParseMaps(_lines);
        var seeds = input[0].Replace("seeds: ", "").Split(" ").Select(long.Parse).ToList();

        return seeds.Select(seed => maps.Aggregate(seed, (current, map) => map.ProcessMap(current))).Min().ToString();
    }

    public string Part2()
    {
        var lines = _lines.ToList();
        var maps = ConvertMap.ParseMaps(lines);
        var initialSeeds = lines[0].Replace("seeds: ", "").Split(" ").Select(long.Parse).ToArray();

        var result = long.MaxValue; 
    
        var startingSeed = 0l;
        for (var seedIdx = 0; seedIdx < initialSeeds.Length; seedIdx++)
        {
            if (seedIdx % 2 == 0)
                startingSeed = initialSeeds[seedIdx];
            else
            {
                for (var _ = 0; _ < initialSeeds[seedIdx]; _++)
                {
                    var seedValue = startingSeed + _;
                    seedValue = maps.Aggregate(seedValue, (current, map) => map.ProcessMap(current));
                    if (result > seedValue)
                        result = seedValue;
                }
            }
        }

        return result.ToString();
    }
}