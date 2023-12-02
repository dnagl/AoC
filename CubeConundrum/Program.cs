using CubeConundrum;

const string inputFile = "input.txt";

Stage1(inputFile);
Stage2(inputFile);
return;

void Stage1(string inputFile)
{
    //restrictions:
    //max 12 red cubes
    //max 13 green cubes
    //max 14 blue cubes

    var result = Parse(inputFile)
        .Where(game => game.Drafts.All(draft => draft.Red <= 12 && draft.Green <= 13 && draft.Blue <= 14))
        .Select(game => game.Id)
        .Sum();
    
    Console.WriteLine($"Stage 1: {result}");
}

void Stage2(string inputFile)
{
    var result = Parse(inputFile)
        .Select(game => game.GetMinimumCubeSet())
        .Select(x => x.Blue * x.Green * x.Red)
        .Sum();
    
    Console.WriteLine($"Stage 1: {result}");
}

IEnumerable<Game> Parse(string inputFile) => File.ReadLines(inputFile).Select(Game.Parse);