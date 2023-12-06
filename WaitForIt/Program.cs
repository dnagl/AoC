using WaitForIt;

const string inputFile = "input.txt";

Stage1();
Stage2();
return;

void Stage1()
{
    var lines = File.ReadLines(inputFile);
    var races = new List<Race>();
    var racesCreated = false;
    foreach (var line in lines)
    {
        var token = line.Split(" ").Where(x => x != "").ToArray();
        for (var i = 1; i < token.Length; i++)
        {
            if (!racesCreated) races.Add(new Race { Time = long.Parse(token[i]) });
            else races[i-1].Distance = long.Parse(token[i]);
        }

        racesCreated = true;
    }

    var result = -1;
    
    foreach (var race in races)
    {
        var results = new Dictionary<long, long>();
        for (var i = 0; i <= race.Time; i++)
        {
            var distance = (race.Time - i) * i;
            results.Add(i, distance);
        }
        
        var x = results.Count(x => x.Value > race.Distance);
        if (result == -1) result = x;
        else result *= x;
    }
    
    Console.WriteLine($"Stage 1: {result}");
}

void Stage2()
{
    var lines = File.ReadLines(inputFile).ToArray();
    var race = new Race
    {
        Time = long.Parse(lines[0].Replace("Time:", "").Replace(" ", "")),
        Distance = long.Parse(lines[1].Replace("Distance:", "").Replace(" ", ""))
    };
    
    var results = new Dictionary<long, long>();
    for (var i = 0; i <= race.Time; i++)
    {
        var distance = (race.Time - i) * i;
        results.Add(i, distance);
    }
        
    var result = results.Count(x => x.Value > race.Distance);
    
    Console.WriteLine($"Stage 2: {result}");
}