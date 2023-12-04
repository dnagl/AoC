using CubeConundrum;

const string inputFile = "input.txt";

Stage1();
Stage2();
return;

void Stage1()
{
    var result = Parse()
        .Where(game => game.Drafts.All(draft => draft is { Red: <= 12, Green: <= 13, Blue: <= 14 }))
        .Select(game => game.Id)
        .Sum();
    
    Console.WriteLine($"Stage 1: {result}");
}

void Stage2()
{
    var result = Parse()
        .Select(game => game.GetMinimumCubeSet())
        .Select(x => x.Blue * x.Green * x.Red)
        .Sum();
    
    Console.WriteLine($"Stage 1: {result}");
}

IEnumerable<Game> Parse() => File.ReadLines(inputFile).Select(Game.Parse);