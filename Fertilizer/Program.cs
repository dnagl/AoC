using Fertilizer;

const string inputFile = "input.txt";

Stage1();
Stage2();
return;

void Stage1()
{
    var lines = File.ReadLines(inputFile).ToList();
    var maps = ConvertMap.ParseMaps(lines);
    var seeds = lines[0].Replace("seeds: ", "").Split(" ").Select(long.Parse).ToList();

    var result = seeds.Select(seed => maps.Aggregate(seed, (current, map) => map.ProcessMap(current))).Min();

    Console.WriteLine($"Stage 1: {result}");
}

void Stage2()
{
    var lines = File.ReadLines(inputFile).ToArray();
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

    Console.WriteLine($"Stage 2: {result}");
}