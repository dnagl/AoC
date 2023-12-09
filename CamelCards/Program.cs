using CamelCards;

const string inputFile = "input.txt";
Stage1();
Stage2();
return;

void Stage1()
{
    var lines = File.ReadLines(inputFile);
    
    var result = lines.Select(x => x.Split(" "))
        .Select(x => (GetPairType(x[0]), int.Parse(x[1]), x[2]))
        .OrderBy(x => x.Item1).ThenBy(x => x.Item3, new CardSort())
        .Select((x, i) => (i + 1) * x.Item2).Sum();

    Console.WriteLine($"Stage 1: {result}");
}

void Stage2()
{
    var lines = File.ReadLines(inputFile);
 
    var result = lines.Select(x => x.Split(" "))
        .Select(x =>  (GetPairWildcard(x[0]), int.Parse(x[1]), x[0]))
        .OrderBy(x => x.Item1).ThenBy(x=> x.Item3, new CardSort(1))
        .Select((x,i) => (i+1)*x.Item2).Sum();
    
    Console.WriteLine($"Stage 2: {result}");
}

int GetPairType(string s)
{
    var group = s.GroupBy(x => x).ToArray();
    return (group.Length, group.Max(x => x.Count())) switch
    {
        (5,1) => 0,
        (4,2) => 1,
        (3,2) => 2,
        (3,3) => 3,
        (2,3) => 4,
        (2,4) => 5,
        (1,6) => 6,
        _ => -1
    };
}

int GetPairWildcard(string s) => !s.Contains('J')
    ? GetPairType(s)
    : s.Replace("J", "").Distinct()
        .Select(c => GetPairType(s.Replace('J', c)))
        .Prepend(GetPairType(s)).Max();