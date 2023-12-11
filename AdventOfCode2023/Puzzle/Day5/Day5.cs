namespace AdventOfCode2023.Puzzle.Day5;

[PuzzleInformation(Name ="If You Give A Seed A Fertilizer", Day = 5, Complete = true)]
public class Day5 : PuzzleBase<Day5>
{
    public Day5() : base("input.txt") { }

    public override string Part1()
    {
        var input = Lines.ToList();
        var maps = ConvertMap.ParseMaps(Lines);
        var seeds = input[0].Replace("seeds: ", "").Split(" ").Select(long.Parse).ToList();

        return seeds.Select(seed => maps.Aggregate(seed, (current, map) => map.ProcessMap(current))).Min().ToString();
    }

    public override string Part2()
    {
        var lines = Lines.ToList();
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