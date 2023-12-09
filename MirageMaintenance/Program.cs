const string inputFile = "input.txt";

Solution();
return;

void Solution()
{
    var resultPart1 = 0l;
    var resultPart2 = 0l;
    var lines = File.ReadLines(inputFile)
        .Select(x => x.Split(" ").Select(long.Parse).ToArray()).ToList();
    
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

        resultPart1 += valuePart1;
        resultPart2 += valuePart2;
    }
    
    Console.WriteLine($"Stage 1: {resultPart1} {resultPart1 == 1806615041}");
    Console.WriteLine($"Stage 2: {resultPart2}");
}